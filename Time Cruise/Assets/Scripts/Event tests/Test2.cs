using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test2 : MonoBehaviour {

    public UnityEvent OnTest2Finished;
   
    public void DoSomething()
    {
        Debug.Log("doing something");
        DialogueTrigger dialogueTriggerCapitaine = GameObject.Find("Capitaine").GetComponent<DialogueTrigger>();
        dialogueTriggerCapitaine.SetSentence("Ceci est la nouvelle sentence");
        OnTest2Finished.Invoke();
    }
    
}
