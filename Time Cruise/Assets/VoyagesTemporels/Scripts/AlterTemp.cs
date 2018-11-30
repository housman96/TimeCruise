using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterTemp : MonoBehaviour {

   /* [Tooltip("Un string qui représente l'ID, doit être unique pour cet objet, pour toutes les scenes!")]
    public string id;
    private Vector2 posIni;

    void OnEnable() {
        Loader.OnFinishAwake += Awake;
    }


    void OnDisable() {
        Loader.OnFinishAwake -= Awake;
    }

    protected virtual void Awake() {
        Vector2 pos = gameObject.transform.position;
        posIni = new Vector2(pos.x, pos.y);
        if (Loader.instance == null) 
            return;
        Loader.instance.register(this);
    }

    public virtual void Load(Changement chgt) {
        Vector2 pos = gameObject.transform.position;

        pos.x = chgt.m_x;
        pos.y = chgt.m_y;

        gameObject.transform.position = pos;
        Debug.Log("Teleport de " + id + "en " + pos);
        posIni = pos;
    }

    public virtual Changement Save() {
        Vector2 pos = gameObject.transform.position;
        Debug.Log(posIni + "    " + pos);
        if (posIni == pos) {
            return null;
        }
        //return new Changement(pos.x,pos.y);
        return new Changement();
    }*/
}
