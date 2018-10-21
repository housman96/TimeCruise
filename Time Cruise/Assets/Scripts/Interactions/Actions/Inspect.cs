using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inspect", menuName = "Actions/Inspect")]
public class Inspecter : Action
{
    
    public override void onAction()
    {
        base.onAction();
        Debug.Log("Inspection");
        // TODO : Gérer l'inspection
    }

    public override string GetActionName()
    {
        return "Inspecter";
    }

}
