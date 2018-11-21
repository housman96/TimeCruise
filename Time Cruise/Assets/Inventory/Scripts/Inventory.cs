using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Inventory : MonoBehaviour {
    //public int inventorySize = 5;
    public List<Item>inventory ;

    protected virtual void Awake() {
        //inventory = new Item[inventorySize];
    }

    public void loadInventory(GameObject inventoryUI) {
        for (int k = 0; k < inventory.Count; k++) {
            loadSlot(k, inventoryUI);
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

    private void changeImageSettings(int alpha, bool texteAffiche, Image inventoryImage) {
        Color color = inventoryImage.color;
        color.a = alpha;
        inventoryImage.color = color;
        inventoryImage.transform.GetChild(0).gameObject.SetActive(texteAffiche);
    }


}
