using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanVaVoirIsabelleEvanouie : MonoBehaviour
{
    public Transform basEscalierSousSol;
    public Transform hautEscalierSousSol;
    public Transform placeSalon;

    public GameObject carnetInspecter;
    public GameObject carnetPasInspecter;

    public AILerp JeanPathfinding;
    public AIDestinationSetter JeanDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        JeanDestination.target = basEscalierSousSol;

        yield return new WaitForSeconds(1);

        carnetInspecter.SetActive(true);
        carnetPasInspecter.SetActive(false);

        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });

        JeanPathfinding.Teleport(hautEscalierSousSol.position);
        JeanDestination.target = placeSalon;

        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
