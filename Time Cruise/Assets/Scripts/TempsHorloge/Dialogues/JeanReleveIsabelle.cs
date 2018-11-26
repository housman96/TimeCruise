using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanReleveIsabelle : MonoBehaviour
{

    public DialogueTrigger Jean;
    public GameObject Isabelle;

    public UnityEvent OnEnd;
    public UnityEvent EcartezVous;

    public void StartDialogue()
    {
        StartCoroutine("Dialogue");
    }

    private IEnumerator Dialogue()
    {
        Jean.SetSentence("Ecartez-vous, laissez la respirer.");
        yield return new WaitForSeconds(1);
        EcartezVous.Invoke();
        yield return new WaitForSeconds(2);
        Jean.ResetSentence();

        yield return new WaitForSeconds(3);

        Isabelle.transform.Rotate(0, 0, -90);
        yield return new WaitForSeconds(1);

        Jean.SetSentence("Faites attention maintenant. Et reposez vous.");
        yield return new WaitForSeconds(3);
        Jean.ResetSentence();
        
        OnEnd.Invoke();
    }
}
