using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllerAuSalon : MonoBehaviour {
    public Transform hautEscalierSousSol;
    public Transform salon;

    public AILerp luigiPathfinding;
    public AIDestinationSetter luigiDestination;

    public UnityEvent OnEnd;

    void Start () {
        StartCoroutine("LuigiVaAuSalon");
	}

    private IEnumerator LuigiVaAuSalon()
    {
        yield return new WaitUntil(() => { return luigiPathfinding.reachedEndOfPath; });

        luigiPathfinding.Teleport(hautEscalierSousSol.position);
        luigiDestination.target = salon;
        
        yield return new WaitUntil(() => { return luigiPathfinding.reachedEndOfPath; });

        OnEnd.Invoke();
    }
}
