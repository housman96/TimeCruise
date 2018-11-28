using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMatelotsDebutHorloge : MonoBehaviour
{
    public DialogueTrigger MatelotA;
    public DialogueTrigger MatelotB;

    private void Start()
    {
        StartCoroutine("Dialogue");
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        MatelotA.ResetSentence();
        MatelotB.ResetSentence();
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            MatelotA.SetSentence("On devrait vraiment prévenir le capitaine.");
            yield return new WaitForSeconds(2);
            MatelotA.ResetSentence();

            MatelotB.SetSentence("On le préviendra quand il viendra, sois patient.");
            yield return new WaitForSeconds(2);
            MatelotB.ResetSentence();

            yield return new WaitForSeconds(Random.Range(6f, 15f));
        }
    }
}
