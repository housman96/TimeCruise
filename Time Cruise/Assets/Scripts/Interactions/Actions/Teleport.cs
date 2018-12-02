using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Action {
    public string epoque;
    public string nameObj;
    public override void onAction() {
        base.onAction();
        Debug.Log("Teleportation");
        TimeTravelManager.instance.TimeTravel(epoque, nameObj);
    }

    public override string GetActionName() {
        return "Interagir";
    }

    public override void GetReferenceObject(Interactable interactable) {
        base.GetReferenceObject(interactable);
    }
}
