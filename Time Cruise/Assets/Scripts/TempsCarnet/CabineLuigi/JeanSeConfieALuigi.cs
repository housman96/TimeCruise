using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JeanSeConfieALuigi : MonoBehaviour
{
    public DialogueTrigger Jean;
    public DialogueTrigger Luigi;
    public UnityEvent OnEnd;

    private bool inspecteurAEspionne = false;
    private bool inspecteurPresent = false;

    private bool fini = false;

    private bool texte1 = false;
    private bool texte2 = false;
    private bool texte3 = false;
    private bool texte4 = false;
    private bool texte5 = false;
    private bool texte6 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!fini && collision.tag == "Player" && collision.isTrigger == false)
        {
            StopAllCoroutines();
            Jean.ResetSentence();
            Luigi.ResetSentence();
            inspecteurPresent = true;
            StartCoroutine(Attend());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger == false)
        {
            inspecteurPresent = false;
        }
    }

    public void Espionne()
    {
        inspecteurAEspionne = true;
        StartCoroutine(Attend());
    }

    public void Stop()
    {
        StopAllCoroutines();
        Jean.ResetSentence();
        Luigi.ResetSentence();
        fini = true;
    }

    public IEnumerator Attend()
    {
        yield return new WaitUntil(() => { return !inspecteurPresent; });
        if (inspecteurAEspionne && !fini)
            StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        if (!texte1)
        {
            Luigi.SetSentence("Dé koi vouliéz vous mé parrrler mio ami?");
            yield return new WaitForSeconds(4);
            Luigi.ResetSentence();
            texte1 = true;
        }

        if (!texte2)
        {
            Jean.SetSentence("Il se trouve mon ami, que j’ai un terrible secret...");
            yield return new WaitForSeconds(6);
            Jean.SetSentence("Si je suis sûr cette croisière c’est pour trouver ma famille. Je suis le fils caché, le bâtard, du capitaine.");
            yield return new WaitForSeconds(8);
            Jean.ResetSentence();
            texte2 = true;
        }

        if (!texte3)
        {
            Luigi.SetSentence("Comment ést-cé possiblé?");
            yield return new WaitForSeconds(3);
            Luigi.ResetSentence();
            texte3 = true;
        }

        if (!texte4)
        {
            Jean.SetSentence("Le capitaine a rencontré ma mère sur le front de la grande. Il a d’ailleur quitté ma mère en même temps que le front.");
            yield return new WaitForSeconds(8);
            Jean.SetSentence("C’est pour ça que j’essaye de discuter avec Pierre et Julie, pour en apprendre plus sur ma famille. Mais Isabelle ne doit jamais l’apprendre, sinon elle me turait.");
            yield return new WaitForSeconds(8);
            Jean.ResetSentence();
            texte4 = true;
        }

        if (!texte5)
        {
            Luigi.SetSentence("Vous né l'avéz pas avoué au capitiana?");
            yield return new WaitForSeconds(4);
            Luigi.ResetSentence();
            texte5 = true;
        }

        if (!texte6)
        {
            Jean.SetSentence("Non pas encore, je crois que j’attends un signe du ciel pour me décider.");
            yield return new WaitForSeconds(6);
            Jean.ResetSentence();
            texte6 = true;
        }

        fini = true;
        OnEnd.Invoke();
    }
}
