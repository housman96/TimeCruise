using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speak", menuName = "Actions/Speak")]
public class Speak : Action {

    public Dialogue dialogue;

    public override void onAction()
    {
        base.onAction();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public override string GetActionName()
    {
        return "Parler";
    }

}
