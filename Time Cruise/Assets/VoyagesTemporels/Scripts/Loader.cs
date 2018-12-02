using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    public delegate void finishAwake();
    public static event finishAwake OnFinishAwake;

    [System.Serializable]
    public struct epoque
    {
        public string name;
        public int numAssocie;
    }

    [Tooltip("Associer les epoques chronologiquement à un numéro, commencer à 0 et aller de 1 en 1")]
    public epoque[] epoques;
    public Dictionary<string, int> epoqueInt;

    [Tooltip("Numero de l'epoque dans laquelle on est (doit correspondre à epoques)")]
    public int epoqueActuelle;
    public static Loader instance;
    [HideInInspector]
    public Dictionary<string, Changement>[] changements;// sacré délire
    private List<AlterTemp> listObjAlter;//=new List<AlterTemp>();

    private void Awake()
    {//singleton + dontdestroyOnLoad
        Time.timeScale = 1.0f;
        if (instance == null)
        {
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
        else
        {
            Destroy(gameObject);
        }
    }

    public void register(AlterTemp script)
    {
        listObjAlter.Add(script);
    }

    private void Load()
    {
        //Debug.Log("epoque Actuelle : "+epoqueActuelle);
        for (int i = epoqueActuelle; i < changements.Length; i++)
        { //supprime les changements faits sur les epoques futures
            //Debug.Log("Clear epoque " + i);
            changements[i].Clear();
        }

        int iEpoqueCopie = -1; //epoque passée la plus proche sur laquelle il y a eu des changements

        for (int i = epoqueActuelle - 1; i >= 0; i--)
        {
            if (changements[i] != null && changements[i].Count > 0)
            {
                iEpoqueCopie = i;
                break;
            }
        }
        //Debug.Log("Epoque passe avec chgt la plus proche " + iEpoqueCopie);
        if (iEpoqueCopie == -1)
            return;
        foreach (AlterTemp obj in listObjAlter)
        {
            //Debug.Log("Load " + obj.id);
            if (changements[iEpoqueCopie].ContainsKey(obj.id))
            {
                //Debug.Log("Clee reconnue : " + obj.id);
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

    private void Save()
    {
        foreach (AlterTemp obj in listObjAlter)
        {
            //Debug.Log("Save " + obj.id);
            Changement chgt = obj.Save();
            if (chgt != null)
            {
                changements[epoqueActuelle][obj.id]= chgt;
            }
        }
    }

    private void InitializeEpoqueInt()
    {//mettre des clefs du meme nom que les scenes!! et leur attribuer un int dans l'ordre chronologique!!
        epoqueInt = new Dictionary<string, int>();
        /*epoqueInt.Add("J-2",0);
        epoqueInt.Add("J-1", 1);
        epoqueInt.Add("J", 2);*/
        foreach (epoque ep in epoques)
        {
            epoqueInt[ep.name] =ep.numAssocie;
        }
    }

    private void InitializeChangements()
    {
        int nbEpoques = 0;
        int valuePrec = -1;
        foreach (int value in epoqueInt.Values)
        { //plusieurs présents...correction rapide
            if (valuePrec == value)
            {
                break;
            }
            valuePrec = value;
            nbEpoques++;
        }
        changements = new Dictionary<string, Changement>[nbEpoques];
        for (int i = 0; i < changements.Length; i++)
        {
            changements[i] = new Dictionary<string, Changement>();
        }
    }

    public void TimeTravel(string epoque)
    {
        Save();
        epoqueActuelle = epoqueInt[epoque]; //on change d'epoque
        listObjAlter = new List<AlterTemp>(); //on reset ces obj
        SceneManager.LoadScene(epoque);
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        Load();//load des objets modifies
    }
}
