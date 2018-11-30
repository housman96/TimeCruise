using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterTempChest :MonoBehaviour  {

    public string id;
    List<Item> inventoryIni;
    List<Item> inventoryCurrent;
    void OnEnable() {
        Loader.OnFinishAwake += Awake;
    }


    void OnDisable() {
        Loader.OnFinishAwake -= Awake;
    }

    protected void Awake() {
        inventoryCurrent = GetComponent<FurnitureInventory>().inventory;
        inventoryIni = new List<Item>(inventoryCurrent);

        if (Loader.instance == null)
            return;
        Loader.instance.register(this);
    }

    public void Load(ChangementInventory chgt) {

        for (int k = 0; k < inventoryIni.Count; k++) {
            if ( chgt.m_inventory[k]!=null) {
                inventoryCurrent[k] = chgt.m_inventory[k];
            }
        }
    }

    public ChangementInventory Save() {//Save que les changements
        List < Item > invChgts= new List<Item>(inventoryCurrent);
        for (int k = 0; k < inventoryIni.Count;k++) {
            if ((inventoryIni[k] == null && inventoryCurrent[k] != null) || (inventoryIni[k] != null && inventoryCurrent[k] == null)) {
            }
            else if ((inventoryIni[k]==null && inventoryCurrent[k]==null) || (inventoryIni[k].itemName == inventoryCurrent[k].itemName)) {
                invChgts[k]=null;
            }
        }
        return new ChangementInventory(invChgts);
    }
}
