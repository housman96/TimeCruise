using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public Item item;

    public void RemoveFromGame() {
        gameObject.transform.position = new Vector2(1000,1000);
    }

    public bool isPicked() {
        return (gameObject.transform.position.x == 1000);
    }
}
