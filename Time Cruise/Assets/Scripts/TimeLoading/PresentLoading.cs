using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentLoading : MonoBehaviour {

    public GameObject StethoscopeBeforeMoved;
    public GameObject StethoscopeAfterMoved;

    // Use this for initialization
    void Start () {
        if(TimeAlterations.StethoscopeMoved)
        {
            if(StethoscopeBeforeMoved != null)
            {
                StethoscopeBeforeMoved.SetActive(false);
            }
        }
        else
        {
            if (StethoscopeAfterMoved != null)
            {
                StethoscopeAfterMoved.SetActive(true);
            }
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
