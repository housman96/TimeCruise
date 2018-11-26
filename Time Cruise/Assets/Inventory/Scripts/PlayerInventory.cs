using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : Inventory {

    public GameObject playerInventoryUI;

    protected override void Awake() {
        //inventorySize = 1;
        base.Awake();
        loadInventory();
    }

    private void loadInventory() {
        base.loadInventory(playerInventoryUI);
    }

    public void changeInventory(Item item) {
        inventory[0] = item;
        loadInventory();
    }
}
