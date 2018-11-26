using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DettesPierreALuigi : MonoBehaviour
{

    public DialogueTrigger Luigi;
    public DialogueTrigger Pierre;
    public DialogueTrigger Isabelle;

    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine("Dialogue");
    }

    private IEnumerator Dialogue()
    {
        Luigi.SetSentence("Monsieur, il va vous falloir payer vos dettes si vous ne voulez pas de problème.");
        yield return new WaitForSeconds(3);
        Luigi.ResetSentence();

        Pierre.SetSentence("Je vous avais dit de ne pas en parler en public !");
        yield return new WaitForSeconds(3);
        Pierre.ResetSentence();

        Isabelle.SetSentence("Ciel, mon fils est en danger !");
        yield return new WaitForSeconds(3);
        Isabelle.ResetSentence();

        Isabelle.transform.Rotate(0, 0, 90);

        yield return new WaitForSeconds(1);
        OnEnd.Invoke();

        Pierre.SetSentence("Mère, que vous arrive-t-il?!");
        yield return new WaitForSeconds(3);
        Pierre.ResetSentence();
    }
}
