using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    public Dictionary<string, int> epoqueInt;

    public delegate void finishAwake();
    public static event finishAwake OnFinishAwake;

    public int epoqueActuelle;
    public static Loader instance;
    [HideInInspector]
    public Dictionary<string, Changement>[] changements;// sacré délire
    private List<AlterTemp> listObjAlter;//=new List<AlterTemp>();

    private void Awake() {//singleton + dontdestroyOnLoad
        if (instance == null) {
            instance = this;
            listObjAlter = new List<AlterTemp>();
            InitializeEpoqueInt();
            InitializeChangements();

            //epoqueActuelle = epoqueInt.Count-1;
            DontDestroyOnLoad(gameObject);

            if (OnFinishAwake != null)
                OnFinishAwake();

            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void register(AlterTemp script) {
        listObjAlter.Add(script);
    }

    private void Load() {
        Debug.Log("epoque Actuelle : "+epoqueActuelle);
        for (int i = epoqueActuelle; i < changements.Length; i++) { //supprime les changements faits sur les epoques futures
            Debug.Log("Clear epoque " + i);
            changements[i].Clear();
        }

        int iEpoqueCopie=-1; //epoque passée la plus proche sur laquelle il y a eu des changements

        for (int i= epoqueActuelle-1;i>=0;i--) {
            if (changements[i] != null && changements[i].Count>0) {
                iEpoqueCopie = i;
                break;
            }
        }
        Debug.Log("Epoque passe avec chgt la plus proche " + iEpoqueCopie);
        if (iEpoqueCopie == -1)
            return;
        foreach (AlterTemp obj in listObjAlter) {
            Debug.Log("Load " + obj.id);
            if (changements[iEpoqueCopie].ContainsKey(obj.id)) {
                Debug.Log("Clee reconnue : " + obj.id);
                obj.Load(changements[iEpoqueCopie][obj.id]);
            }
        }
        


        /*for (int i = 0; i < epoqueActuelle; i++) {
            foreach (AlterTemp obj in listObjAlter) {
                Debug.Log("Load " + obj.id);
                if (changements[i].ContainsKey(obj.id)) {
                    Debug.Log("Clee reconnue : " + obj.id);
                    obj.Load(changements[i][obj.id]);
                }
            }
        }*/
    }

    private void Save() {
        foreach (AlterTemp obj in listObjAlter) {
            Debug.Log("Save " + obj.id);
            Changement chgt = obj.Save();
            if (chgt != null) {
                changements[epoqueActuelle].Add(obj.id,chgt);
            }
        }
    }

    private void InitializeEpoqueInt() {//mettre des clefs du meme nom que les scenes!! et leur attribuer un int dans l'ordre chronologique!!
        epoqueInt = new Dictionary<string, int>();
        epoqueInt.Add("J-2",0);
        epoqueInt.Add("J-1", 1);
        epoqueInt.Add("J", 2);
    }

    private void InitializeChangements() {
        changements = new Dictionary<string, Changement>[epoqueInt.Count];
        for (int i = 0; i < changements.Length; i++) {
            changements[i] = new Dictionary<string, Changement>();
        }
    }

    public void TimeTravel(string epoque) {
        Save();
        epoqueActuelle = epoqueInt[epoque]; //on change d'epoque
        listObjAlter = new List<AlterTemp>(); //on reset ces obj
        SceneManager.LoadScene(epoque);
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        Load();//load des objets modifies
    }
}
