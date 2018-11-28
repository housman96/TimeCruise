using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LuigiQuandIsabelleSevanouie : MonoBehaviour
{
    public Transform placeCible;

    public AILerp luigiPathfinding;
    public AIDestinationSetter luigiDestination;

    public UnityEvent OnEnd;

    public void StartMovement()
    {
        luigiDestination.target = placeCible;
        OnEnd.Invoke();
    }
}
