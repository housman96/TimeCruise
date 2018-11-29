using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EcouterPorteCapitaine : MonoBehaviour
{
    public PlayerInventory inventory;
    public PlayerController controller;

    public DialogueTrigger inspecteur;
    public DialogueTrigger Paul;
    public DialogueTrigger Maurice;

    public GameObject MauriceCorps;

    public GameObject porte;
    public GameObject stethoscope;

    public GameObject horlogePasCassee;
    public GameObject horlogeCassee;
    public GameObject OhHorlogeCassee;

    public GameObject popupEcouter;

    public Transform PaulSalonJean;
    public AIDestinationSetter PaulDestination;

    public UnityEvent OnEndEcoute;
    public UnityEvent OnEndMauriceReleve;

    public void StartPorteFermee()
    {
        StartCoroutine("PorteFermee");
    }

    private IEnumerator PorteFermee()
    {
        inspecteur.SetSentence("*Je dois trouver un moyen de savoir ce qu’ils se disent.*", false);
        yield return new WaitForSeconds(3);
        inspecteur.ResetSentence();
    }

    public void StartEcoute()
    {
        StartCoroutine("Ecoute");
    }

    private IEnumerator Ecoute()
    {
        controller.LockMoves();
        popupEcouter.SetActive(false);
        porte.SetActive(false);

        Paul.SetSentence("J’en ai déjà fait bien assez ! Vous devez taire la vérité !", false);
        yield return new WaitForSeconds(3);
        Paul.ResetSentence();

        Maurice.SetSentence("Votre secret en restera un tant que vous ferez ce que je vous demande.", false);
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        Paul.SetSentence("Vous ne vous en tirerez pas si facilement !", false);
        yield return new WaitForSeconds(3);
        Paul.ResetSentence();

        Maurice.SetSentence("C’est cela, allez geindre dans votre coin. Mais n’oubliez pas ce que vous me devez.", false);
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        horlogePasCassee.SetActive(false);
        horlogeCassee.SetActive(true);
        Maurice.SetSentence("*CRASH*", false);
        yield return new WaitForSeconds(1);

        Maurice.transform.Rotate(0, 0, -90);
        PaulDestination.target = PaulSalonJean;

        yield return new WaitForSeconds(1);
        Maurice.ResetSentence();

        stethoscope.SetActive(true);
        inventory.changeInventory(null);

        OnEndEcoute.Invoke();

        controller.UnlockMoves();

        yield return new WaitForSeconds(5);
        Maurice.transform.Rotate(0, 0, 90);
        Maurice.SetSentence("Ce fou m’a poussé sans aucune raison. Et voilà que mon horloge est cassée…");
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        OhHorlogeCassee.SetActive(true);

        OnEndMauriceReleve.Invoke();
    }
}
