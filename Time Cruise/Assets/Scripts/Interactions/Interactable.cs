using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    private string interactionName;
    public Action action;
    public GameObject popup;
    public Text actionName;
    public KeyCode actionKeyCode;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        DisplayPopup();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!popup.activeInHierarchy)
        {
            DisplayPopup();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        HindPopup();
    }


    public void Interact()
    {
        action.GetReferenceObject(this);
        action.onAction();
    }

    public void DisplayPopup()
    {
        actionName.text = action.GetActionName() + " : " + actionKeyCode.ToString();
        RectTransform popupTransform = popup.GetComponent<RectTransform>();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        screenPos += new Vector3(0, popupTransform.rect.height, 0);
        popupTransform.SetPositionAndRotation(screenPos, Quaternion.identity);
        popup.SetActive(true);
    }

    public void HindPopup()
    {
        popup.SetActive(false);
    }

}
