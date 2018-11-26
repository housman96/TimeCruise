using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LuigiEstUnMafieuIsabellePierre : MonoBehaviour {

    public DialogueTrigger Isabelle;
    public DialogueTrigger Pierre;

    public UnityEvent OnEnd;
    
    public void StartDialogue()
    {
        StartCoroutine("Dialogue");	
	}

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(9);

        Isabelle.SetSentence("Savais-tu que Luigi fait partie de la mafia? On raconte qu’il aurait déjà tué.");
        yield return new WaitForSeconds(3);
        Isabelle.ResetSentence();

        Pierre.SetSentence("Mère, ne vous inquiétez pas de lui. Il ne nous fera aucun mal.");
        yield return new WaitForSeconds(3);
        Pierre.ResetSentence();

        OnEnd.Invoke();
    }
}
