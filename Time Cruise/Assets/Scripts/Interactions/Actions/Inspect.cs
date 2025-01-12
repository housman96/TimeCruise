﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : Action
{

    private FurnitureInventory inventory; //besoin de cette ref pour charger le bon inventaire
    public override void onAction()
    {
        base.onAction();
        Debug.Log("Inspection");

        FindObjectOfType<InventoryManager>().StartInventory(inventory);
        // TODO : Gérer l'inspection
    }

    public override string GetActionName()
    {
        return "Inspecter";
    }
    public override void GetReferenceObject(Interactable interactable) {
        base.GetReferenceObject(interactable);
        inventory = interactable.gameObject.GetComponent<FurnitureInventory>();
    }


}
