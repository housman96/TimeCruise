using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortezSeancePaulHorloge : MonoBehaviour
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

        Jean.SetSentence("Inspecteur, pouvez vous nous laissez? Nous avons rendez vous.", false);
        yield return new WaitForSeconds(2);
        Jean.ResetSentence();

        sortie.SetActive(true);

        OnEnd.Invoke();
    }
}
