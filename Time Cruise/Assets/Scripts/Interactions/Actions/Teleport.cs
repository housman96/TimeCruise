using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Teleport", menuName = "Actions/Teleport")]
public class Teleport : Action {
    public string epoque;
    public override void onAction() {
        base.onAction();
        Debug.Log("Teleportation");
        Loader.instance.TimeTravel(epoque);
    }

    public override string GetActionName() {
        return "Interagir";
    }

    public override void GetReferenceObject(Interactable interactable) {
        base.GetReferenceObject(interactable);
    }
}
