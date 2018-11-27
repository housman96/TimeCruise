using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JulieJalouse : MonoBehaviour
{
    public DialogueTrigger Julie;

    public Transform cibleJulie;
    public AILerp JuliePathfinding;
    public AIDestinationSetter JulieDestination;
    
    public UnityEvent OnEnd;

    public void StartJalousie()
    {
        StartCoroutine("Jalousie");
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        Julie.ResetSentence();
    }

    private IEnumerator Jalousie()
    {
        JulieDestination.target = cibleJulie;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return JuliePathfinding.reachedEndOfPath; });

        Julie.SetSentence("Pourquoi Marie traîne-t-elle autant avec cet homme? Elle est déjà prise...");
        yield return new WaitForSeconds(3);
        Julie.ResetSentence();

        OnEnd.Invoke();
    }
}
