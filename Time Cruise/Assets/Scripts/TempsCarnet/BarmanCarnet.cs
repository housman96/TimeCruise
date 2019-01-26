using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmanCarnet : MonoBehaviour
{
    public DialogueTrigger barman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            barman.SetSentence("Je me demande qui a bu tout l’alcool? Il y a quelques jours les réserves étaient encore pleines.");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            barman.ResetSentence();
    }
}
