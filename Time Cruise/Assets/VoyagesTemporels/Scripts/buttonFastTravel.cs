using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonFastTravel : MonoBehaviour {
    string m_epoque;
    static int m_epoqueTP=-1;
    int m_numEpoque;

    public void Initialize(string epoque, int numEpoque) {
        m_epoque = epoque;
        m_numEpoque = numEpoque;
        Text buttonText = transform.GetChild(0).GetComponent<Text>();
        buttonText.text = epoque;
    }

    public void setEpoque() {
        m_epoqueTP = m_numEpoque;
        Debug.Log(m_epoqueTP);
        //TimeTravelManager.instance.FastTimeTravel(m_epoque);
    }

    public void FastTravel() {
        if (m_epoqueTP>=0)
            Journal.instance.FastTimeTravel(m_epoqueTP);
    }

}
