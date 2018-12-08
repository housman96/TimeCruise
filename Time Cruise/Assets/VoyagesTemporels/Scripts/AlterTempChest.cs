using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterTempChest :AlterTemp  {
    //List<Item> inventoryIni;
    public List<Item> inventoryCurrent;
    void OnEnable() {
        Loader.OnFinishAwake += Awake;
    }


    void OnDisable() {
        Loader.OnFinishAwake -= Awake;
    }

    protected void Awake() {
        inventoryCurrent = GetComponent<FurnitureInventory>().inventory;
        //inventoryIni = new List<Item>(inventoryCurrent);

        if (Loader.instance == null)
            return;
        Loader.instance.register(this);
    }

    public override void Load<T>(T chgt) {

        ChangementInventory chgt2 = chgt as ChangementInventory;
        if (chgt2 == null) {
            return;
        }
        for (int k = 0; k < inventoryCurrent.Count; k++) {
            //if (chgt2.m_inventory[k]!=null) {
            inventoryCurrent[k] = chgt2.m_inventory[k];
            //}
        }
    }

    public override Changement Save() {//Save que les changements
        List < Item > invChgts= new List<Item>(inventoryCurrent);
        foreach(Item i in invChgts) {
            if (i != null)
                Debug.Log("nom item : " + i.itemName);
            else
                Debug.Log("nom item : " + null);
        }
        /*for (int k = 0; k < inventoryIni.Count;k++) {
            if ((inventoryIni[k] == null && inventoryCurrent[k] != null) || (inventoryIni[k] != null && inventoryCurrent[k] == null)) {
            }
            else if ((inventoryIni[k]==null && inventoryCurrent[k]==null) || (inventoryIni[k].itemName == inventoryCurrent[k].itemName) ) {
                invChgts[k]=null;
            }
        }*/
        return new ChangementInventory(invChgts);
    }
}
