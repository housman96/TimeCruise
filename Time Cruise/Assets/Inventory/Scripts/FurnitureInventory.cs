using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureInventory : Inventory {

    private PlayerInventory playerInventory;

    protected override void Awake() {
        base.Awake();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void onSlotClicked(int slotNumber, GameObject inventoryUI) {
        Item temp = playerInventory.inventory[0];//1 seul element
        playerInventory.changeInventory(inventory[slotNumber]);
        inventory[slotNumber] = temp;
        loadSlot(slotNumber, inventoryUI);
    }
}
