using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllerVoirIsabelleEvanouie : MonoBehaviour
{
    public DialogueTrigger Marie;
    public DialogueTrigger Julie;

    public Transform MarieVersIsabelle;
    public Transform JulieVersIsabelle;

    public AILerp JuliePathfinding;
    public AIDestinationSetter JulieDestination;

    public AILerp MariePathfinding;
    public AIDestinationSetter MarieDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        MarieDestination.target = MarieVersIsabelle;
        JulieDestination.target = JulieVersIsabelle;

        yield return new WaitForSeconds(2);

        Julie.SetSentence("Marie, va chercher le médecin au plus vite, nous avons besoin de lui.");
        yield return new WaitForSeconds(3);
        Julie.ResetSentence();

        Marie.SetSentence("Oui madame.");
        yield return new WaitForSeconds(1);

        OnEnd.Invoke();

        yield return new WaitForSeconds(2);
        Marie.ResetSentence();
    }
}
