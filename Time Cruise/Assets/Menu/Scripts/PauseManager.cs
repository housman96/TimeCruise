﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour {

    public static bool isPaused = false;
    //public GameObject pauseMenu;

    public Animator initiallyOpen;
    //public PlayerController player;
    private int m_OpenParameterId;
    private Animator m_Open;
    private GameObject m_PreviouslySelected;
    //private int close = 0;

    const string k_OpenTransitionName = "Open";
    const string k_ClosedStateName = "Closed";


    void Update() {
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
        //player.UnlockMoves();
        ResumePanel();
    }

    public void Pause() {
        isPaused = !isPaused;
        //player.LockMoves();
        Time.timeScale = 0f;
        PausePanel();
    }

    //gestion des panel

    public void ResumePanel() {
        CloseCurrent();
        m_Open = null;
        m_PreviouslySelected = null;
    }

    public void PausePanel() {
        m_OpenParameterId = Animator.StringToHash(k_OpenTransitionName);

        if (initiallyOpen == null)
            return;

        OpenPanel(initiallyOpen);
    }

    public void OpenPanel(Animator anim) {
        if (m_Open == anim)
            return;

        anim.gameObject.SetActive(true);
        var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;


        CloseCurrent();
        //close = 0;

        m_PreviouslySelected = newPreviouslySelected;

        m_Open = anim;
        m_Open.SetBool(m_OpenParameterId, true);
        //m_Open.SetInteger(m_OpenParameterId,1);

        GameObject go = FindFirstEnabledSelectable(anim.gameObject);

        SetSelected(go);
    }

    static GameObject FindFirstEnabledSelectable(GameObject gameObject) {
        GameObject go = null;
        var selectables = gameObject.GetComponentsInChildren<Selectable>(true);
        foreach (var selectable in selectables) {
            if (selectable.IsActive() && selectable.IsInteractable()) {
                go = selectable.gameObject;
                break;
            }
        }
        return go;
    }

    public void CloseCurrent() {
        if (m_Open == null)
            return;

        m_Open.SetBool(m_OpenParameterId, false);
        //Debug.Log(close);
        //m_Open.SetInteger(m_OpenParameterId, close);
        SetSelected(m_PreviouslySelected);
        StartCoroutine(DisablePanelDeleyed(m_Open));
        m_Open = null;
    }

    IEnumerator DisablePanelDeleyed(Animator anim) {
        bool closedStateReached = false;
        bool wantToClose = true;
        while (!closedStateReached && wantToClose) {
            if (!anim.IsInTransition(0))
                closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);//a modifier ... tableau de string et utiliser close

            wantToClose = !anim.GetBool(m_OpenParameterId);
            //wantToClose = !(anim.GetInteger(m_OpenParameterId)==1);
            yield return new WaitForEndOfFrame();
        }

        if (wantToClose)
            anim.gameObject.SetActive(false);
    }

    private void SetSelected(GameObject go) {
        EventSystem.current.SetSelectedGameObject(go);
    }
}
