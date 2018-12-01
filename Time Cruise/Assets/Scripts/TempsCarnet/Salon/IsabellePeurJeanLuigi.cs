using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsabellePeurJeanLuigi : MonoBehaviour
{
    public DialogueTrigger Isabelle;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);

        Isabelle.SetSentence("Ces deux là sont amis? Je ne peux pas laisser la mafia comploter contre mon fils.");
        yield return new WaitForSeconds(5);
        Isabelle.ResetSentence();

        OnEnd.Invoke();
    }
}
