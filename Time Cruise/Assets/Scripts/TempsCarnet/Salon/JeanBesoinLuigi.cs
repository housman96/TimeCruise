using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanBesoinLuigi : MonoBehaviour
{
    public DialogueTrigger Jean;
    public DialogueTrigger Luigi;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        Jean.SetSentence("Mon ami, je dois vous demander un service.");
        yield return new WaitForSeconds(3);
        Jean.ResetSentence();

        Luigi.SetSentence("Comment pouis-gié vous aider?");
        yield return new WaitForSeconds(3);
        Luigi.ResetSentence();

        Jean.SetSentence("J’ai besoin de me confier à quelqu’un. Je dois aller en consultation avec Paul, mais puis-je vous rejoindre dans votre cabine une fois mon travail terminé?");
        yield return new WaitForSeconds(7);
        Jean.ResetSentence();

        Luigi.SetSentence("Vous pouvéz compter sourrr moi, amigo. Gié vous attendrrré dans mia cabiné.");
        yield return new WaitForSeconds(5);
        Luigi.ResetSentence();

        OnEnd.Invoke();
    }
}
