using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public Item item;
    public Image playerInventoryImage;

    private void Awake() {
        changeInventory(item);
    }

    public void changeInventory (Item newItem) {
        item = newItem;
        if (item != null) {
            changeImageSettings(1, false);
            playerInventoryImage.sprite = item.icon;
        }
        else {
            changeImageSettings(0, true);
        }
    }

    private void changeImageSettings(int alpha,bool texteAffiche) {
        Color color = playerInventoryImage.color;
        color.a = alpha;
        playerInventoryImage.color = color;
        playerInventoryImage.transform.GetChild(0).gameObject.SetActive(texteAffiche);
    }

    public bool isEmpty() {
        return (item == null);
    }
}
