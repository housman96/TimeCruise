using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArriveeTempsHorloge : MonoBehaviour
{
    public DialogueTrigger inspecteur;

    public UnityEvent OnArriveeEnd;

    void Start()
    {
        StartCoroutine("Reflection");
    }

    private IEnumerator Reflection()
    {
        inspecteur.SetSentence("*Que s’est il passé?*", false);
        yield return new WaitForSeconds(2);
        inspecteur.ResetSentence();

        inspecteur.SetSentence("*Le capitaine est encore en vie ! Et l’horloge fonctionne…*", false);
        yield return new WaitForSeconds(2);
        inspecteur.ResetSentence();

        OnArriveeEnd.Invoke();
    }
}
