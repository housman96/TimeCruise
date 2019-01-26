using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectDoorClosed : Action
{

    PlayerInventory playerInventory;

    public UnityEvent PorteFermee;
    public UnityEvent EcouterPorte;

    private void Awake()
    {
    }

    public override void onAction()
    {
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null && playerInventory.inventory[0] != null && playerInventory.inventory[0].name == "Stethoscope")
        {
            EcouterPorte.Invoke();
        }
        else
        {
            PorteFermee.Invoke();
        }
    }

    public override string GetActionName()
    {
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null && playerInventory.inventory[0] != null && playerInventory.inventory[0].name == "Stethoscope")
        {
            return "Ecouter";
        }
        else
        {
            return "Inspecter";
        }
    }

    public override void GetReferenceObject(Interactable interactable)
    {
        base.GetReferenceObject(interactable);
    }
}
