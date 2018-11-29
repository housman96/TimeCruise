using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectHorlogePasCassee : MonoBehaviour
{
    public DialogueTrigger inspecteur;

    public UnityEvent OnEnd;

    public void Inspection()
    {
        StartCoroutine("Reflection");
    }

    private IEnumerator Reflection()
    {
        inspecteur.SetSentence("*Nom de Zeus !*", false);
        yield return new WaitForSeconds(4);
        inspecteur.ResetSentence();

        OnEnd.Invoke();
    }
}
