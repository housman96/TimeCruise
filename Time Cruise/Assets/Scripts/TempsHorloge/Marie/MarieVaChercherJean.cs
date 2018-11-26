using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarieVaChercherJean : MonoBehaviour
{
    public Transform basEscalierSousSol;
    public Transform hautEscalierSousSol;
    public Transform versJean;

    public AILerp MariePathfinding;
    public AIDestinationSetter MarieDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        MarieDestination.target = hautEscalierSousSol;

        yield return new WaitForSeconds(2);

        yield return new WaitUntil(() => { return MariePathfinding.reachedEndOfPath; });

        MariePathfinding.Teleport(basEscalierSousSol.position);
        MarieDestination.target = versJean;

        yield return new WaitUntil(() => { return MariePathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
