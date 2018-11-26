using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarieRevientAuSalon : MonoBehaviour
{
    public Transform basEscalierSousSol;
    public Transform hautEscalierSousSol;
    public Transform placeSalon;

    public AILerp MariePathfinding;
    public AIDestinationSetter MarieDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        MarieDestination.target = basEscalierSousSol;

        yield return new WaitForSeconds(2);

        yield return new WaitUntil(() => { return MariePathfinding.reachedEndOfPath; });

        MariePathfinding.Teleport(hautEscalierSousSol.position);
        MarieDestination.target = placeSalon;

        yield return new WaitUntil(() => { return MariePathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
