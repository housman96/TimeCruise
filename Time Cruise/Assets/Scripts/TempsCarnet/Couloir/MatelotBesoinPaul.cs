using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatelotBesoinPaul : MonoBehaviour
{
    public DialogueTrigger Matelot;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        Matelot.SetSentence("Nous avons besoin de Paul !!");

        OnEnd.Invoke();
    }
}
