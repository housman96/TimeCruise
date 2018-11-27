using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdleIsabelleEvanouie : MonoBehaviour
{
    public DialogueTrigger Julie;
    public DialogueTrigger Pierre;

    private List<string> phrasesIdle;

    private void Start()
    {
        phrasesIdle = new List<string>();
        phrasesIdle.Add("Mère, réveillez vous.");
        phrasesIdle.Add("Mère, que vous arrive-t-il?");
        phrasesIdle.Add("Que quelqu'un fasse quelque chose !");
        phrasesIdle.Add("Mère...");
    }

    public void StartDialogue()
    {
        StartCoroutine("Dialogue");
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        Julie.ResetSentence();
        Pierre.ResetSentence();
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        while(true)
        {
            DialogueTrigger enfantQuiParle = Julie;
            if (Random.value > 0.5)
                enfantQuiParle = Pierre;

            string phraseADire = phrasesIdle[Random.Range(0, phrasesIdle.Count)];
            enfantQuiParle.SetSentence(phraseADire);
            yield return new WaitForSeconds(2);
            enfantQuiParle.ResetSentence();

            yield return new WaitForSeconds(Random.Range(2f,5f));
        }
    }
}
