using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectObject : Action
{
    public UnityEvent onInspect;

    public override void onAction()
    {
        base.onAction();
        Debug.Log("Inspection");
        onInspect.Invoke();
    }

    public override string GetActionName()
    {
        return "Inspecter";
    }
    public override void GetReferenceObject(Interactable interactable)
    {
        base.GetReferenceObject(interactable);
    }
}
