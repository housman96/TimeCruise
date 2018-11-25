using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test2 : MonoBehaviour {

    public UnityEvent OnTest2Finished;

    public DialogueTrigger dialogueTriggerCapitaine;

    public void DoSomething()
    {
        Debug.Log("doing something");
        dialogueTriggerCapitaine.SetSentence("Ceci est la nouvelle sentence");
        OnTest2Finished.Invoke();
    }
    
}
