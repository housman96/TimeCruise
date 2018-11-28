using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    protected string actionName;

    public virtual void onAction()
    {
        // To be overwritten
    }

    public virtual string GetActionName()
    {
        return actionName;
    }

    public virtual void GetReferenceObject (Interactable interactable) { //certaines actions necessitent une ref vers l'obj 
        // To be overwritten
    }
}
