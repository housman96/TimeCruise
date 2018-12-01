using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OuverturePorte : MonoBehaviour {

    public GameObject porte;

    public UnityEvent onEnd;

    private void Start()
    {
        if (porte == null)
            porte = gameObject;
    }

    public void Ouverture(float delai = 0)
    {
        StartCoroutine(Ouvre(delai));
    }

    private IEnumerator Ouvre(float delai)
    {
        yield return new WaitForSeconds(delai);
        porte.SetActive(false);

        onEnd.Invoke();
    }
}
