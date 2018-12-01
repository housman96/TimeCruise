using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeplacementMemeEtage : MonoBehaviour
{
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
        DestinationSetter.target = destinationFinale;
        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => { return Pathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
