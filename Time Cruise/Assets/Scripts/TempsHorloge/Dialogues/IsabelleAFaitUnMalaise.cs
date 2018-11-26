using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsabelleAFaitUnMalaise : MonoBehaviour
{

    public DialogueTrigger Marie;
    public DialogueTrigger Jean;

    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine("Dialogue");
    }

    private IEnumerator Dialogue()
    {
        Marie.SetSentence("Madame Isabelle a fait un malaise dans le salon, vous devez venir tout de suite.");
        yield return new WaitForSeconds(2);
        Marie.ResetSentence();

        Jean.SetSentence("Je viens tout de suite.");
        yield return new WaitForSeconds(1.5f);
        Jean.ResetSentence();

        Jean.SetSentence("Inspecteur, vous venez avec nous?", false);
        yield return new WaitForSeconds(1.5f);
        Jean.ResetSentence();

        OnEnd.Invoke();
    }
}
