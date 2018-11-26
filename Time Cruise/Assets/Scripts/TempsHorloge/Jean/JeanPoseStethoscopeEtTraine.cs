using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanPoseStethoscopeEtTraine : MonoBehaviour
{
    public Transform placePoseStethoscope;
    public GameObject stethoscope;
    public Transform placeTraine;

    public AILerp JeanPathfinding;
    public AIDestinationSetter JeanDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        JeanDestination.target = placePoseStethoscope;

        yield return new WaitForSeconds(2);

        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });

        stethoscope.SetActive(true);
        yield return new WaitForSeconds(1);

        JeanDestination.target = placeTraine;
        
        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
