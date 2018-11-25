using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrivéePaul : MonoBehaviour
{
    public DialogueTrigger capitaine;
    public DialogueTrigger paul;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine(dialogue1());
    }

    public IEnumerator dialogue1()
    {
        paul.SetSentence("Capitaine? Vous m’avez demandé?");
        yield return new WaitForSeconds(2);
        paul.ResetSentence();

        capitaine.SetSentence("C’est exact.");
        yield return new WaitForSeconds(2);
        capitaine.ResetSentence();

        capitaine.SetSentence("Inspecteur, laissez nous seul s’il vous plaît.");
        yield return new WaitForSeconds(2);
        capitaine.ResetSentence();

        OnEnd.Invoke();
    }
}
