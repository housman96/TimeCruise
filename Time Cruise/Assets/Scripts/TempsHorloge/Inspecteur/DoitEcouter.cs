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

    public void SortieBureau()
    {
        sortie = true;
        if(finDiscussion)
            StartCoroutine("Reflection");
    }

    public void FinDiscussion()
    {
        finDiscussion = true;
        if (sortie)
            StartCoroutine("Reflection");
    }

    private IEnumerator Reflection()
    {
        inspecteur.SetSentence("*Je dois trouver un moyen de savoir ce qu’ils se disent.*", false);
        yield return new WaitForSeconds(2);
        inspecteur.ResetSentence();

        OnEnd.Invoke();
    }
}
