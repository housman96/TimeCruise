using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CapitaineVaPiloter : MonoBehaviour
{
    public Transform basEscalierPont;
    public Transform hautEscalierPont;
    public Transform placePilotage;

    public AILerp MauricePathfinding;
    public AIDestinationSetter MauriceDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        MauriceDestination.target = basEscalierPont;

        yield return new WaitForSeconds(2);

        yield return new WaitUntil(() => { return MauricePathfinding.reachedEndOfPath; });

        MauricePathfinding.Teleport(hautEscalierPont.position);
        MauriceDestination.target = placePilotage;

        yield return new WaitUntil(() => { return MauricePathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
