using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortezSeancePaulHorloge : MonoBehaviour
{
    public GameObject sortie;

    public AILerp PaulPathfinding;
    public AILerp JeanPathfinding;
    public DialogueTrigger Jean;

    public GameObject carnetInspecter;
    public GameObject carnetPasInspecter;

    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine("Sortez");
    }

    public IEnumerator Sortez()
    {
        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });
        yield return new WaitUntil(() => { return PaulPathfinding.reachedEndOfPath; });

        carnetInspecter.transform.Translate(1000, 0, 0);
        carnetPasInspecter.SetActive(true);

        Jean.SetSentence("Inspecteur, pouvez vous nous laissez? Nous avons rendez vous.", false);
        sortie.SetActive(true);
        yield return new WaitForSeconds(4);
        Jean.ResetSentence();
        carnetInspecter.SetActive(false);

        OnEnd.Invoke();
    }
}
