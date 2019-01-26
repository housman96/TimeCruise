using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused=false;
    public GameObject pauseMenu;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
                Resume();
            else
                Pause();
        }
	}

    public void Resume() {
        isPaused = !isPaused;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Pause() {
        isPaused = !isPaused;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
}
