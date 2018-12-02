using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoutonFastTravel : MonoBehaviour {
    string m_epoque;
    static string m_epoqueTP;
    int m_numEpoque;

    public void Initialize(string epoque,int numEpoque) {
        m_epoque = epoque;
        m_numEpoque = numEpoque;
        Text buttonText = transform.GetChild(0).GetComponent<Text>();
        buttonText.text = epoque;
    }

    public void setEpoque() {
        m_epoqueTP = m_epoque;
        //TimeTravelManager.instance.FastTimeTravel(m_epoque);
    }

    public void FastTravel() {
        TimeTravelManager.instance.FastTimeTravel(m_epoqueTP);
    }

}
