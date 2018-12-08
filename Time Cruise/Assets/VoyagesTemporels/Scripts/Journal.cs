using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Journal : MonoBehaviour {
    public static Journal instance;
    public GameObject JournalGrid;//gridLayout qui contient les boutons du journal
    [HideInInspector]
    public bool presentAccuse = false;

    private bool[] TPUnlock;
    private bool[,] recordTimeTravel;
    private string[] intToStringEpoque = {"Horloge","Carnet","","Présent" };
    private void Awake() {
        if (instance == null) {
            ResetJournal();
            Initialize();
            instance =this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void TimeTravel(int epoqueInt) { //Loader previent le journal des time travel
        string currentScene = SceneManager.GetActiveScene().name;
        if (!Loader.instance.epoqueInt.ContainsKey(currentScene))
            return;
        int currentSceneInt = Loader.instance.epoqueInt[currentScene];
        //unlock fastTravel
        if (!recordTimeTravel[currentSceneInt, epoqueInt] && recordTimeTravel[epoqueInt, currentSceneInt]) {//on a déjà fait le voyage inverse
            TPUnlock[epoqueInt] = true;
            JournalGrid.transform.GetChild(epoqueInt).gameObject.SetActive(true);
            TPUnlock[currentSceneInt] = true;
            JournalGrid.transform.GetChild(currentSceneInt).gameObject.SetActive(true);
        }
        else {
            recordTimeTravel[currentSceneInt, epoqueInt] = true; //record ce voyage temporel
        }
    }

    public void FastTimeTravel(int epoqueInt) {
        string currentScene = SceneManager.GetActiveScene().name;
        int currentSceneInt = Loader.instance.epoqueInt[currentScene];
        if (epoqueInt == 3) {
            //reste à retirer les objts à retirer
            if (currentSceneInt == 0) {
                Loader.instance.TimeTravel("PresentHorloge");
            }
            else if (currentSceneInt == 1) {
                if (presentAccuse) {
                    Loader.instance.TimeTravel("PresentAccuse");
                }
                else {
                    Loader.instance.TimeTravel("PresentJournal");
                }
            }
            else {
                Loader.instance.TimeTravel("PresentHorloge");
            }
        }
        else if (epoqueInt == 31) {
            //reste à retirer les objts à retirer du coffre
            Loader.instance.TimeTravel(intToStringEpoque[epoqueInt]);
        }
        else {
            Loader.instance.TimeTravel(intToStringEpoque[epoqueInt]);
        }
    }

    public void ResetJournal() {//desactive tous les boutons
        for (int i = 0; i < JournalGrid.transform.childCount; i++) { 
            JournalGrid.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void Initialize() {//desactive tous les boutons
        int nbEpoques = Loader.instance.epoqueInt.Values.Count;
        TPUnlock = new bool[nbEpoques];
        recordTimeTravel=new bool [nbEpoques,nbEpoques];
        InitializeButtons();
    }

    public void InitializeButtons() {
        foreach (int epoque in Loader.instance.epoqueInt.Values) { 
            GameObject buttonGO = JournalGrid.transform.GetChild(epoque).gameObject;
            buttonFastTravel button = buttonGO.GetComponent<buttonFastTravel>();
            button.Initialize(intToStringEpoque[epoque], epoque);
        }
    }
}
