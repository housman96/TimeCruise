using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OhLhorlogeEstCassee : MonoBehaviour
{
    public DialogueTrigger inspecteur;

    public UnityEvent OnEnd;

    private bool ended = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!ended && collision.tag == "Player")
        {
            ended = true;
            StartCoroutine("Reflection");
        }
    }

    private IEnumerator Reflection()
    {
        inspecteur.SetSentence("*L’horloge est à nouveau cassée, je devrais peut être la regarder de plus près.*", false);
        yield return new WaitForSeconds(4);
        inspecteur.ResetSentence();

        OnEnd.Invoke();
    }
}
