using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortezChambreCapitaine : MonoBehaviour
{
    public GameObject sortie;

    public DialogueTrigger Jean;

    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine("Sortez");
    }

    public IEnumerator Sortez()
    {
        Jean.SetSentence("Inspecteur, pouvez vous nous laissez? J'ai besoin de lui parler en privé...", false);
        sortie.SetActive(true);
        yield return new WaitForSeconds(6);
        Jean.ResetSentence();

        OnEnd.Invoke();
    }
}
