using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private PlayerController playerController;
    private Inventory activeInventory;
    public GameObject InventoryUI;
    public KeyCode closeInventory;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void StartInventory(Inventory inventory) {
        activeInventory = inventory;
        playerController.LockMoves();
        activeInventory.loadInventory(InventoryUI);
        ShowInventory();
    }
    public void ShowInventory() {
        InventoryUI.SetActive(true);
    }
    public void CloseInventory() {
        InventoryUI.SetActive(false);
    }
    public void EndInventory() {
        playerController.UnlockMoves();
        CloseInventory();
    }
    public void onSlotClicked (int slot) {
        activeInventory.onSlotClicked(slot,InventoryUI);
    }
    private void Update() {
        if (Input.GetKeyDown(closeInventory)) {
            EndInventory();
        }
    }
}
