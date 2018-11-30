using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeplacementMontant2Etages : MonoBehaviour
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
        DestinationSetter.target = basEscalierSousSol;

        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        Pathfinding.Teleport(hautEscalierSousSol.position);
        DestinationSetter.target = basEscalierEtage;

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        Pathfinding.Teleport(hautEscalierEtage.position);
        DestinationSetter.target = destinationFinale;

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
