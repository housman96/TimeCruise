using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanMaMereEstMorte : MonoBehaviour
{
    public DialogueTrigger Jean;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        Jean.SetSentence("Mon dieu, j’attendais un signe mais pas ça...");
        yield return new WaitForSeconds(5);
        Jean.SetSentence("Ma pauvre mère est morte, elle qui a toujours vécu dans la misère alors que mon père vivait dans le luxe de ce bateau...");
        yield return new WaitForSeconds(8);
        Jean.SetSentence("Ca ne peut plus durer, je vais parler au Capitaine.");
        yield return new WaitForSeconds(5);
        Jean.ResetSentence();

        OnEnd.Invoke();
    }
}
