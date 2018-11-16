using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject {

    protected string actionName;

    public virtual void onAction()
    {
        // To be overwritten
    }

    public virtual string GetActionName()
    {
        return actionName;
    }
}
