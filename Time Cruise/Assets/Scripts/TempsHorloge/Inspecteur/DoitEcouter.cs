using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoitEcouter : MonoBehaviour
{
    public DialogueTrigger inspecteur;

    public UnityEvent OnEnd;

    private bool sortie = false;
    private bool finDiscussion = false;

    private bool ended = false;

    public void SortieBureau()
    {
        sortie = true;
        if(finDiscussion && !ended)
            StartCoroutine("Reflection");
    }

    public void FinDiscussion()
    {
        finDiscussion = true;
        if (sortie && !ended)
            StartCoroutine("Reflection");
    }

    private IEnumerator Reflection()
    {
        ended = true;
        inspecteur.SetSentence("*Je dois trouver un moyen de savoir ce qu’ils se disent.*", false);
        yield return new WaitForSeconds(2);
        inspecteur.ResetSentence();

        OnEnd.Invoke();
    }
}
