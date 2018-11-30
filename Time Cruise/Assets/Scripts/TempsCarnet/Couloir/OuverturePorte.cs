using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour {

    public GameObject porte;

    private void Start()
    {
        if (porte == null)
            porte = gameObject;
    }

    public void Ouverture()
    {
        porte.SetActive(true);
    }
}
