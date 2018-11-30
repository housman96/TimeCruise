using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementInventory  {

    public List<Item> m_inventory;

    public ChangementInventory(List<Item> inventory) {
        m_inventory = new List<Item>(inventory);
    }
}
