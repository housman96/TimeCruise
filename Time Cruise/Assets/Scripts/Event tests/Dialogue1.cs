using System.Collections;
using System;
using UnityEngine;

public class Dialogue1 : MonoBehaviour {

    public DialogueTrigger capitaine;
    public DialogueTrigger marie;

	public void StartDialogue()
    {
        StartCoroutine(dialogue1());
    }

    public IEnumerator dialogue1()
    {
        capitaine.SetSentence("Coucou Marie");
        yield return new WaitForSeconds(2);

        capitaine.ResetSentence();
        marie.SetSentence("Bonjour capitaine");
        yield return new WaitForSeconds(2);

        marie.ResetSentence();
        capitaine.SetSentence("On baise ?");
        yield return new WaitForSeconds(2);

        capitaine.ResetSentence();
        marie.SetSentence("Mmmmh... Ok !");
        yield return new WaitForSeconds(2);

        marie.ResetSentence();

    }


}
