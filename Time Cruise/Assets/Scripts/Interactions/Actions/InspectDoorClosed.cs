using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectDoorClosed : Action {

    public override void onAction() {
        base.onAction();
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory.inventory[0] != null && playerInventory.inventory[0].name=="Stethoscope") {
            Debug.Log("Ecoute a la porte");
            return;
        }
        else {
            Debug.Log("La porte est fermee");
        }
    }

    public override string GetActionName() {
        return "Interagir";
    }

    public override void GetReferenceObject(Interactable interactable) {
        base.GetReferenceObject(interactable);
        
    }
}
