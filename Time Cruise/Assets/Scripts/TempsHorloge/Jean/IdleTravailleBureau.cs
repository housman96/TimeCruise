using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTravailleBureau : MonoBehaviour
{
    public DialogueTrigger Jean;

    private List<string> phrasesIdle;
    private bool stop;

    private void Start()
    {
        phrasesIdle = new List<string>();
        phrasesIdle.Add("C’est fascinant...");
        phrasesIdle.Add("Je me demande de quoi Paul veut me parler…");
        phrasesIdle.Add("C’est donc comme ça que ça se forme…");
        phrasesIdle.Add("Cet Hans Spemann est un génie...");
        phrasesIdle.Add("Le blastopore...");
        StartCoroutine("Dialogue");
    }

    public void StopIdle()
    {
        StopAllCoroutines();
        Jean.ResetSentence();
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            string phraseADire = phrasesIdle[Random.Range(0, phrasesIdle.Count)];
            Jean.SetSentence(phraseADire);
            yield return new WaitForSeconds(3);
            Jean.ResetSentence();

            yield return new WaitForSeconds(Random.Range(4f, 6f));
        }
    }
}
