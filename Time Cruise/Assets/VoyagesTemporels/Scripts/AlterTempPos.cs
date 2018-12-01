using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterTempPos : AlterTemp {
    //private Vector2 posIni;

    void OnEnable() {
        Loader.OnFinishAwake += Awake;
    }


    void OnDisable() {
        Loader.OnFinishAwake -= Awake;
    }

    protected virtual void Awake() {
        Vector2 pos = gameObject.transform.position;
        //posIni = new Vector2(pos.x, pos.y);
        if (Loader.instance == null) 
            return;
        Loader.instance.register(this);
        id = GetComponent<PickUp>().item.itemName;
    }

    public override void Load<T>(T chgt) {
        changementPos chgt2 = chgt as changementPos;
        if (chgt == null)
            return;
        Vector2 pos = gameObject.transform.position;

        pos.x = chgt2.m_x;
        pos.y = chgt2.m_y;

        gameObject.transform.position = pos;
        Debug.Log("Teleport de " + id + "en " + pos);
        //posIni = pos;
    }

    public override Changement Save() {
        Vector2 pos = gameObject.transform.position;
        //Debug.Log(posIni + "    " + pos);
        /*if (posIni == pos) {
            return null;
        }*/
        return new changementPos(pos.x,pos.y);
        //return new ChangementPos();
    }
}
