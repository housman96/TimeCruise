using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanHarcelePierre : MonoBehaviour
{
    public DialogueTrigger Jean;
    public DialogueTrigger Pierre;
    public AILerp JeanPathfinding;
    public UnityEvent OnEnd;

    void Start()
    {
        StartCoroutine(Harcelement());
    }

    public IEnumerator Harcelement()
    {
        yield return new WaitUntil(() => { return JeanPathfinding.reachedEndOfPath; });

        Jean.SetSentence("Pierre s’il vous plaît laissez moi entrer, j’aimerais vous parler.");
        yield return new WaitForSeconds(3);
        Jean.ResetSentence();

        Pierre.SetSentence("J’en ai assez de répondre à vos questions Jean, arrêtez de me harceler maintenant !", false);
        yield return new WaitForSeconds(3);
        Pierre.ResetSentence();

        OnEnd.Invoke();
    }
}
