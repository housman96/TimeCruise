using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeplacementDescendant2Etages : MonoBehaviour
{
    public Transform basEscalierSousSol;
    public Transform hautEscalierSousSol;
    public Transform basEscalierEtage;
    public Transform hautEscalierEtage;
    public Transform destinationFinale;

    public AILerp Pathfinding;
    public AIDestinationSetter DestinationSetter;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        DestinationSetter.target = hautEscalierEtage;

        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        Pathfinding.Teleport(basEscalierEtage.position);
        DestinationSetter.target = hautEscalierSousSol;

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        Pathfinding.Teleport(basEscalierSousSol.position);
        DestinationSetter.target = destinationFinale;

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
