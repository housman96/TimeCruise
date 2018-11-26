using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Test1 : MonoBehaviour {
    
    public UnityEvent OnAction1Finished;

    void Start()
    {
        StartCoroutine("testFunction");
    }

    private IEnumerator testFunction()
    {
        Debug.Log("testFunction");
        DateTime time = System.DateTime.Now;
        Debug.Log(time);
        DateTime trigger = time.AddSeconds(5);
        while (System.DateTime.Now.CompareTo(trigger) < 0)
        {
            yield return null;
        }
        Debug.Log(System.DateTime.Now);
        OnAction1Finished.Invoke();
    }
}
