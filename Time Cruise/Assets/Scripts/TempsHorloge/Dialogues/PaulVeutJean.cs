using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaulVeutJean : MonoBehaviour
{
    public DialogueTrigger Paul;
    public DialogueTrigger Jean;

    public Transform basEscalierSousSol;
    public Transform hautEscalierSousSol;
    public Transform placePaulCabineJean;
    public Transform placeJeanCabineJean;

    public AILerp PaulPathfinding;
    public AIDestinationSetter PaulDestination;
    public AILerp JeanPathfinding;
    public AIDestinationSetter JeanDestination;

    public UnityEvent OnArriveAJean;
    public UnityEvent OnArriveeCabineJean;

    public void StartAction()
    {
        StartCoroutine("Action");
    }

    private IEnumerator Action()
    {
        yield return new WaitUntil(() => { return PaulPathfinding.reachedEndOfPath; });
        OnArriveAJean.Invoke();

        Paul.SetSentence("J’ai besoin d’une séance tout de suite. Je vous en prie.");
        yield return new WaitForSeconds(3);
        Paul.ResetSentence();

        Jean.SetSentence("Suivez moi dans ma cabine, je vais m’occuper de vous.");
        yield return new WaitForSeconds(3);
        Jean.ResetSentence();

        JeanDestination.target = hautEscalierSousSol;

        yield return new WaitForSeconds(2);

        PaulDestination.target = hautEscalierSousSol;

        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });
        JeanPathfinding.Teleport(basEscalierSousSol.position);
        JeanDestination.target = placeJeanCabineJean;

        yield return new WaitUntil(() => { return PaulPathfinding.reachedEndOfPath; });
        PaulPathfinding.Teleport(basEscalierSousSol.position);
        PaulDestination.target = placePaulCabineJean;

        OnArriveeCabineJean.Invoke();
    }
}
