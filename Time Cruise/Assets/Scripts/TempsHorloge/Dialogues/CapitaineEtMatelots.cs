using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CapitaineEtMatelots : MonoBehaviour
{
    public DialogueTrigger MatelotA;
    public DialogueTrigger MatelotB;
    public DialogueTrigger Maurice;

    public GameObject messagePasPrendre;
    public GameObject messagePrendre;

    public AILerp MatelotAPathfinding;
    public AIDestinationSetter MatelotADestination;
    public AILerp MatelotBPathfinding;
    public AIDestinationSetter MatelotBDestination;
    public AILerp MauricePathfinding;
    public AIDestinationSetter MauriceDestination;

    public Transform matelotAMessagePourVous;
    public Transform matelotATable;

    public Transform MauriceTable;

    public Transform MauriceCoin;

    public Transform matelotACoin;
    public Transform matelotBCoin;

    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine("Dialogue");
    }

    private IEnumerator Dialogue()
    {
        MatelotADestination.target = matelotAMessagePourVous;
        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => { return MatelotAPathfinding.reachedEndOfPath; });

        MatelotA.SetSentence("Capitaine, nous avons reçu un message, vous devez voir ça.");
        yield return new WaitForSeconds(4);
        MatelotA.ResetSentence();

        MatelotADestination.target = matelotATable;
        yield return new WaitForSeconds(.1f);
        MauriceDestination.target = MauriceTable;
        yield return new WaitForSeconds(.9f);

        yield return new WaitUntil(() => { return MatelotAPathfinding.reachedEndOfPath; });
        messagePasPrendre.SetActive(true);

        MatelotB.SetSentence("La mère de Jean est décédée.");
        yield return new WaitForSeconds(4);
        MatelotB.ResetSentence();

        yield return new WaitUntil(() => { return MauricePathfinding.reachedEndOfPath; });

        Maurice.SetSentence("Hmm... Je vois...");
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        Maurice.SetSentence("Nous le préviendrons à la fin de la croisière. Inutile de l’alarmer pour l’instant. Qui sait ce qu’il pourrait faire sur un bateau au milieu de la mer.");
        yield return new WaitForSeconds(1);
        MauriceDestination.target = MauriceCoin;
        yield return new WaitForSeconds(4);
        Maurice.ResetSentence();

        MatelotADestination.target = matelotACoin;
        MatelotBDestination.target = matelotBCoin;

        messagePasPrendre.SetActive(false);
        messagePrendre.SetActive(true);

        OnEnd.Invoke();
    }
}
