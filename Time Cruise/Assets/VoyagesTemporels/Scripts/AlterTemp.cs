using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlterTemp : MonoBehaviour {

    [Tooltip("Un string qui représente l'ID, doit être unique pour cet objet, pour toutes les scenes!")]
    public string id;
    public virtual void Load<T>(T chgt) {
        //override
    }

    public virtual Changement Save() {
        return null;
    }
}
