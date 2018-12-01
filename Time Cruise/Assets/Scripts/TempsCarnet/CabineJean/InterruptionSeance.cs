using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterruptionSeance : MonoBehaviour
{
    public DialogueTrigger Jean;
    public DialogueTrigger Paul;
    public DialogueTrigger Matelot;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        Matelot.ResetSentence();

        Matelot.SetSentence("Désolé d'interrompre votre séance Monsieur,mais le capitaine n’est plus en état de conduire le bateau.");
        yield return new WaitForSeconds(8);
        Matelot.SetSentence("Il se repose dans ses quartiers. Nous avons besoin de vous pour piloter le navire.");
        yield return new WaitForSeconds(8);
        Matelot.ResetSentence();

        Paul.SetSentence("Plus en état? Il est ivre vous voulez dire! Comme d’habitude. Désolé Docteur, mais je dois y aller.");
        yield return new WaitForSeconds(8);
        Paul.ResetSentence();

        Jean.SetSentence("Pas de problème Paul, j’ai moi aussi quelques choses à faire.");
        yield return new WaitForSeconds(7);
        Jean.ResetSentence();

        OnEnd.Invoke();
    }
}
