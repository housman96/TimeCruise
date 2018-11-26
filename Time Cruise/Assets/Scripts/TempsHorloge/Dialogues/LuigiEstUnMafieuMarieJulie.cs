using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LuigiEstUnMafieuMarieJulie : MonoBehaviour
{

    public DialogueTrigger Marie;
    public DialogueTrigger Julie;

    public UnityEvent OnEnd;
    
    public void StartDialogue()
    {
        StartCoroutine("Dialogue");
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(11);

        Marie.SetSentence("Madame, faites attention à l'Italien, on ne peut pas lui faire confiance.");
        yield return new WaitForSeconds(3);
        Marie.ResetSentence();

        Julie.SetSentence("Sois sans crainte, je ne veux rien avoir à faire avec ce dangereux personnage.");
        yield return new WaitForSeconds(3);
        Julie.ResetSentence();

        OnEnd.Invoke();
    }
}
