using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private PlayerController playerController;
    private FurnitureInventory activeInventory;
    public GameObject InventoryUI;
    //private KeyCode closeInventory=KeyCode.E;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void StartInventory(FurnitureInventory inventory) {
        if (!InventoryUI.activeInHierarchy) {
            activeInventory = inventory;
            playerController.LockMoves();
            activeInventory.loadInventory(InventoryUI);
            ShowInventory();
        }
        else {
            EndInventory();
        }
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
    /*private void Update() {
        if (Input.GetKeyDown(closeInventory) && lastTimeOpen+delayBeforeClose<Time.time) {
            Debug.Log("close");
            EndInventory();
            lastTimeClosed = Time.time;
        }
    }*/
}
