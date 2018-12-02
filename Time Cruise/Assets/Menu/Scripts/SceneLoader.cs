using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


    public void StartGame() {
        SceneManager.LoadScene("CinematiqueIntro");
    }
    /*private int numSceneSelected=-0;

	public void LoadScene (int numScene) {
        Debug.Log("Load Scene " + numScene);
    }

    public void LoadSceneWithNum() {
        Debug.Log("Load Scene " + numSceneSelected);
    }

    public void setNumScene(int i) {
        numSceneSelected = i;
    }*/
}
