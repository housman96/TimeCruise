using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarieTrouveJeanTropFort : MonoBehaviour
{
    public DialogueTrigger Marie;
    public DialogueTrigger Jean;

    public Transform cibleMarie;
    public AILerp MariePathfinding;
    public AIDestinationSetter MarieDestination;

    public UnityEvent OnTriggerJalousie;
    public UnityEvent OnEnd;

    public void StartIlEstTropFort()
    {
        StartCoroutine("IlEstTropFort");
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        Marie.ResetSentence();
        Jean.ResetSentence();
    }

    private IEnumerator IlEstTropFort()
    {
        MarieDestination.target = cibleMarie;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return MariePathfinding.reachedEndOfPath; });


        Marie.SetSentence("Félicitation, vous l’avez sauvez. Qu’est ce que vous êtes fort !");
        yield return new WaitForSeconds(1);
        OnTriggerJalousie.Invoke();
        yield return new WaitForSeconds(2);
        Marie.ResetSentence();

        Jean.SetSentence("Je ne fais que mon travail, c'est normal.");
        yield return new WaitForSeconds(3);
        Jean.ResetSentence();

        OnEnd.Invoke();
    }
}
