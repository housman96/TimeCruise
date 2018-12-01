using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsabelleChutEcoutez : MonoBehaviour
{
    public DialogueTrigger Isabelle;
    public UnityEvent OnEnd;

    private bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.tag == "Player" && collision.isTrigger == false)
        {
            StartCoroutine(TaisezVous());
        }
    }

    public IEnumerator TaisezVous()
    {
        active = false;
        Isabelle.SetSentence("Taisez vous. Ecoutez.", false);
        yield return new WaitForSeconds(4);
        Isabelle.ResetSentence();

        OnEnd.Invoke();
    }
}
