using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MauriceRaleSalon : MonoBehaviour
{
    public DialogueTrigger Maurice;
    public DialogueTrigger Pierre;
    public DialogueTrigger Barman;
    public DialogueTrigger Inspecteur;
    public GameObject ScriptBarman;
    public UnityEvent OnPierreJulieEnd;
    public UnityEvent OnEnd;

    private bool rale = false;
    private bool inspecteurAEntendu = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (rale && collision.tag == "Player" && collision.isTrigger == false)
            inspecteurAEntendu = true;
    }

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        ScriptBarman.SetActive(false);
        Barman.ResetSentence();

        Maurice.SetSentence("Un verre de rouge s’il te plait.");
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        Pierre.SetSentence("Père je ne pense pas que ce soit une bonne idée.");
        yield return new WaitForSeconds(4);
        Pierre.ResetSentence();

        rale = true;
        Maurice.SetSentence("Ne me dit pas ce que je dois faire, fils. J’en ai plus qu’assez des enfants.");
        yield return new WaitForSeconds(8);
        Maurice.SetSentence("Toi avec tes problèmes d’argent avec cet Italien, tu vas te débrouiller cette fois je ne te donnerai pas l’argent.");
        yield return new WaitForSeconds(8);
        Maurice.SetSentence("Quant à toi ma fille, tu es la honte du Marin que je suis, regarde toi, toujours droite, toujours studieuse, mais tu n’as jamais appris à nager de ta vie.");
        yield return new WaitForSeconds(9);
        Maurice.ResetSentence();
        rale = false;

        OnPierreJulieEnd.Invoke();

        if(inspecteurAEntendu)
        {
            StartCoroutine(Reflection());
        }

        yield return new WaitForSeconds(1);
        Maurice.SetSentence("Bon, il vient ce verre?!");
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        Barman.SetSentence("Je suis désolé monsieur mais les réserves sont vide...");
        yield return new WaitForSeconds(6);
        Barman.ResetSentence();

        Maurice.SetSentence("Tous des incompétents sur ce bateau!");
        yield return new WaitForSeconds(4);
        Maurice.ResetSentence();

        OnEnd.Invoke();
    }

    private IEnumerator Reflection()
    {
        Inspecteur.SetSentence("*Julie ne sait pas nager, elle n’a donc pas pu être dans la piscine avec Paul pendant le meurtre du capitaine. Son alibi tombe à l’eau.*", false);
        yield return new WaitForSeconds(10);
        Inspecteur.ResetSentence();
    }
}
