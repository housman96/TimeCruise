using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmanHorloge : MonoBehaviour
{
    public DialogueTrigger barman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            barman.SetSentence("Vous voulez boire quelque chose Inspecteur? Nous pouvons vous proposer de très bons vins.");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            barman.ResetSentence();
    }
}
