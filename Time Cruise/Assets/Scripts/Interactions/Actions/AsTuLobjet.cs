using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsTuLobjet : Action
{
    PlayerInventory playerInventory;

    public string objet;

    public bool gardeLobjet = false;

    public UnityEvent onYes;

    public override void onAction()
    {
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null && playerInventory.inventory[0] != null && playerInventory.inventory[0].name == objet)
        {
            if(!gardeLobjet)
                playerInventory.changeInventory(null);
            onYes.Invoke();
        }
    }

    public override string GetActionName()
    {
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null && playerInventory.inventory[0] != null && playerInventory.inventory[0].name == objet)
        {
            return "Donner";
        }
        else
        {
            return "";
        }
    }

    public override void GetReferenceObject(Interactable interactable)
    {
        base.GetReferenceObject(interactable);
    }
}
