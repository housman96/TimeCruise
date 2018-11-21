using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private const int inventorySize= 5;
    public Item[] inventory=new Item[inventorySize];
    private PlayerInventory playerInventory;

    private void Awake() {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void loadInventory(GameObject inventoryUI) {
        for (int k = 0; k < inventorySize; k++) {
            loadSlot(k,inventoryUI);
        }
    }

    public void loadSlot(int numSlot, GameObject inventoryUI) {
        Item itemK = inventory[numSlot];
        Image slot = inventoryUI.transform.GetChild(numSlot).GetChild(0).GetComponent<Image>();
        if (itemK != null) {
            changeImageSettings(1, false, slot);
            slot.sprite = itemK.icon;
        }
        else {
            changeImageSettings(0, true, slot);
        }
    }

    private void changeImageSettings(int alpha, bool texteAffiche,Image inventoryImage) {
        Color color = inventoryImage.color;
        color.a = alpha;
        inventoryImage.color = color;
        inventoryImage.transform.GetChild(0).gameObject.SetActive(texteAffiche);
    }

    public void onSlotClicked (int slotNumber, GameObject inventoryUI) {
        Item temp = playerInventory.item;
        playerInventory.changeInventory(inventory[slotNumber]);
        inventory[slotNumber] = temp;
        loadSlot(slotNumber,inventoryUI);
    }

}
