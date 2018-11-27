using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : Action {

    private PickUp pickUp;
    public override void onAction() {
        base.onAction();
        Debug.Log("Prise de l'objet");

        PlayerInventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        if (playerInventory.inventory[0] != null) {
            Debug.Log("Inventaire plein");
            return;
        }
        playerInventory.changeInventory(pickUp.item);
        Destroy(pickUp.gameObject);
    }

    public override string GetActionName() {
        return "Prendre";
    }

    public override void GetReferenceObject(Interactable interactable) {
        base.GetReferenceObject(interactable);
        pickUp = interactable.gameObject.GetComponent<PickUp>();
    }
}
