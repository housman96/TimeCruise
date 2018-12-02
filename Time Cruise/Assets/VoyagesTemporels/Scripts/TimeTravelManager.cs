using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeTravelManager : MonoBehaviour {
    [System.Serializable]
    public class liste {
        public List<int> list;
    }

    [Tooltip("faire correspondre chaque scene à un numero unique")]
    public Loader.epoque[] epoques;
    public static TimeTravelManager instance;
    private Dictionary<string, int> epoqueToNumBouton;
    [Tooltip("faire correspondre chaque numéro de scene avec des numéros d'autres scenes vers lesquelles les TP sont possibles")]
    public List<liste> TpPossibles;
    private bool[] TpUnlock;
    public GameObject JournalGrid;
    private Dictionary<string, int> objToEpoque;
   

    private void Awake() {//singleton + dontdestroyOnLoad
        Time.timeScale = 4.0f;
        if (instance == null) {
            instance = this;
            InitializeInstance();
            InitializeButtons();
            //epoqueActuelle = epoqueInt.Count-1;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void InitializeInstance() {
        objToEpoque = new Dictionary<string, int>();
        epoqueToNumBouton = new Dictionary<string, int>();
        foreach (Loader.epoque ep in epoques) {
            epoqueToNumBouton[ep.name] = ep.numAssocie;
        }
        TpUnlock = new bool[epoques.Length];
    }

    public void TimeTravel (string epoque, string nomObj) {
        int epoqueInt = epoqueToNumBouton[epoque];
        if (objToEpoque.ContainsKey(nomObj) && objToEpoque[nomObj] != epoqueInt) {
            TpUnlock[epoqueInt]=true;
            TpUnlock[objToEpoque[nomObj]]=true;
        }
        else {
            objToEpoque[nomObj] = epoqueInt;
        }
        Loader.instance.TimeTravel(epoque);
    }

    public void OnLevelLoading() {
        InitializeJournal();
        string currentScene = SceneManager.GetActiveScene().name;
        int currentSceneInt = epoqueToNumBouton[currentScene];
        foreach (int epoque in TpPossibles[currentSceneInt].list) { //on desactive tous les boutons dans un premier temps
            if (TpUnlock[epoque])
                JournalGrid.transform.GetChild(epoque).gameObject.SetActive(true);
        }
    }

    public void InitializeJournal() {
        for (int i= 0; i < JournalGrid.transform.childCount;i++) { //on desactive tous les boutons dans un premier temps
            JournalGrid.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void InitializeButtons() {
        foreach (string epoque in epoqueToNumBouton.Keys) { //on desactive tous les boutons dans un premier temps
            GameObject buttonGO = JournalGrid.transform.GetChild(epoqueToNumBouton[epoque]).gameObject;
            BoutonFastTravel button= buttonGO.GetComponent<BoutonFastTravel>();
            button.Initialize(epoque, epoqueToNumBouton[epoque]);
        }
    }

    public void FastTimeTravel(string epoque) {
        //ajouter conditions de guillaume genre stethoscope qui disparaît
        Debug.Log("Fast time travel vers : "+epoque );
        Loader.instance.TimeTravel(epoque);
    }
}
