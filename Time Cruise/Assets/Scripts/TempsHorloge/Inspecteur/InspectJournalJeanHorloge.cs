using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectJournalJeanHorloge : MonoBehaviour
{
    public DialogueTrigger inspecteur;

    public UnityEvent OnEnd;

    public void Inspection()
    {
        StartCoroutine("Reflection");
    }

    private IEnumerator Reflection()
    {
        inspecteur.SetSentence("*Apparemment, Paul a pris plusieurs rendez vous pour du soutien psychologique dans les jours qui viennent. Je me demande de quoi il s’agit…*", false);
        yield return new WaitForSeconds(4);
        inspecteur.ResetSentence();

        OnEnd.Invoke();
    }
}
