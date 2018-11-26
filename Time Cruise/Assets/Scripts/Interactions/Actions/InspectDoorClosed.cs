using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inspect", menuName = "Actions/InspectDoorClosed")]
public class InspectDorrClosed : Action {

    public override void onAction() {
        base.onAction();
        PlayerInventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        if (playerInventory.inventory[0].name=="Stéthoscope") {
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
