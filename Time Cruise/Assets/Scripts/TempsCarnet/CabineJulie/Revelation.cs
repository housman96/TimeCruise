using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Revelation : MonoBehaviour
{
    public PlayerController controller;

    public DialogueTrigger Pierre;
    public DialogueTrigger Inspecteur;

    public UnityEvent OnEnd;

    private bool finished = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!finished && collision.tag == "Player" && collision.isTrigger == false)
        {
            finished = true;
            StartCoroutine(Revele());
        }
    }

    public IEnumerator Revele()
    {
        controller.LockMoves();

        Pierre.SetSentence("Ha… Mais qu’est-ce que vous faites ici? Je peux tout expliquer. C’est Julie qui sort avec Marie pas moi.", false);
        yield return new WaitForSeconds(10);
        Pierre.SetSentence("Mais puisque Julie a peur de la réaction de nos parents, elle a préféré leur cacher qu’elle est lesbienne.", false);
        yield return new WaitForSeconds(10);
        Pierre.SetSentence("Je lui passe mes vêtements et elle se fait passer pour moi, comme ça elle peut flirter avec comme elle veut.", false);
        yield return new WaitForSeconds(10);
        Pierre.SetSentence("Vous savez on se ressemble beaucoup ma soeur et moi.", false);
        yield return new WaitForSeconds(6);
        Inspecteur.ResetSentence();

        Inspecteur.SetSentence("*Mais si Pierre n’est pas en couple avec Marie, il n’était pas avec elle pendant le meurtre. De plus il a un mobile pour tuer son père.*", false);
        yield return new WaitForSeconds(10);
        Inspecteur.SetSentence("*Ca fait assez d’indices pour retourner dans le présent pour l'accuser.*", false);
        yield return new WaitForSeconds(8);
        Inspecteur.ResetSentence();

        controller.UnlockMoves();

        OnEnd.Invoke();
    }
}
