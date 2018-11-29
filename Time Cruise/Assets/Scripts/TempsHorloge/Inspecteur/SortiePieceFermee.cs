using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortiePieceFermee : MonoBehaviour {

    public GameObject porte;

    private bool ended;
    public UnityEvent OnEnd;

    private void Start()
    {
        porte.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ended && collision.gameObject.tag == "Player")
        {
            ended = true;
            porte.SetActive(true);
            OnEnd.Invoke();
        }
    }
}
