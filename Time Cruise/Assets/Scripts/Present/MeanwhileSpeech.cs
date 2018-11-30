using System.Collections;
using UnityEngine;

public class MeanwhileSpeech : MonoBehaviour
{
    public DialogueTrigger paulDial;
    public DialogueTrigger matelotDial;
    public DialogueTrigger isabelleDial;
    public DialogueTrigger pierreDial;
    public DialogueTrigger julieDial;
    public DialogueTrigger marieDial;
    public DialogueTrigger luigiDial;
    public DialogueTrigger jeanDial;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Speech());
    }

    public IEnumerator Speech()
    {
        yield return new WaitForSeconds(4);

        /*ISABELLE*/
        isabelleDial.SetSentence("Mon ami combien de temps encore allons nous rester enfermé ici?");
        yield return new WaitForSeconds(5);
        isabelleDial.ResetSentence();

        /*PAUL*/
        paulDial.SetSentence("Dès que l'inspecteur aura trouvé l'assassin de Maurice, Madame.");
        yield return new WaitForSeconds(5);
        paulDial.ResetSentence();

        paulDial.SetSentence("Mais comprennez bien que c'est pour votre sécuritée.");
        yield return new WaitForSeconds(5);
        paulDial.ResetSentence();

        yield return new WaitForSeconds(8);

        /*LUIGI*/
        luigiDial.SetSentence("Penséz vous ké cétté inspéctéour ést rrracisté?");
        yield return new WaitForSeconds(5);
        luigiDial.ResetSentence();

        luigiDial.SetSentence("Gi'é péourrr qu'il mé trrrouvé coupablé à causé dé mio accent.");
        yield return new WaitForSeconds(5);
        luigiDial.ResetSentence();

        /*JEAN*/
        jeanDial.SetSentence("Ne vous inquietez pas mon ami, cet inspecteur me semble quelqu'un de raisonable.");
        yield return new WaitForSeconds(5);
        jeanDial.ResetSentence();

        yield return new WaitForSeconds(8);

        /*PIERRE*/
        pierreDial.SetSentence("Je ne me sens pas confortable à rester enfermé aussi longtemps.");
        yield return new WaitForSeconds(5);
        pierreDial.ResetSentence();

        /*JULIE*/
        julieDial.SetSentence("Ne t'inquiéte pas Pierre, d'ici peu de temps je suis sûr qu'on va découvrir les coupables.");
        yield return new WaitForSeconds(5);
        julieDial.ResetSentence();

        julieDial.SetSentence("Personnelement je parierais sur le médecin et son ami l'italien.");
        yield return new WaitForSeconds(5);
        julieDial.ResetSentence();

        /*MARIE*/
        marieDial.SetSentence("Je ne pense pas que Jean puisse faire quelque chose comme ça.");
        yield return new WaitForSeconds(5);
        marieDial.ResetSentence();

        marieDial.SetSentence("Il est trop gentil.");
        yield return new WaitForSeconds(5);
        marieDial.ResetSentence();

        yield return new WaitForSeconds(25);
        StartCoroutine(Speech());


    }
}
