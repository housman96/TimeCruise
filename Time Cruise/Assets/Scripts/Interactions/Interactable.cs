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
    private bool interact = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.isTrigger == false)
        {
            if (action.GetActionName() != "")
            {
                DisplayPopup();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && other.isTrigger == false)
        {
            Debug.Log("test");
            if (popup != null && !popup.activeInHierarchy && action.GetActionName() != "")
            {
                DisplayPopup();
            }
            if (Input.GetKeyDown(actionKeyCode)) //appelé 2 fois par frame car dans un OntriggerStay d'où le déplacement dans update
            {
                interact = true;
                //Interact(); 
            }
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

    public void Update() {
        if (interact) {
            interact = false;
            Interact();
        }
    }
}
