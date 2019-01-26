using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsabelleVaEspionnerLuigiSalon : MonoBehaviour
{
    public Transform cibleIsabelle;
    public AILerp IsabellePathfinding;
    public AIDestinationSetter IsabelleDestination;

    public UnityEvent OnEnd;

    public void StartDeplacement()
    {
        StartCoroutine("Deplacement");
    }

    private IEnumerator Deplacement()
    {
        IsabelleDestination.target = cibleIsabelle;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => { return IsabellePathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
