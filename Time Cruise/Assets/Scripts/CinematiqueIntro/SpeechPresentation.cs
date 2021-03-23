using System.Collections;
using UnityEngine;

public class SpeechPresentation : MonoBehaviour
{
    public DialogueTrigger paulDial;
    public DialogueTrigger matelotDial;
    public DialogueTrigger isabelleDial;
    public DialogueTrigger pierreDial;
    public DialogueTrigger julieDial;
    public DialogueTrigger marieDial;
    public DialogueTrigger luigiDial;
    public DialogueTrigger jeanDial;

    public void startSpeech()
    {
        StartCoroutine(Speech());
    }
    public IEnumerator Speech()
    {
        yield return new WaitForSeconds(4);

        /*MATELOT*/
        matelotDial.SetSentence("Mesdames et Messieurs veuillez vous présenter à l'inspecteur.", false);
        yield return new WaitForSeconds(7);
        matelotDial.ResetSentence();


        /*ISABELLE*/
        isabelleDial.SetSentence("Je suis Isabelle. La femme, enfin la veuve du Capitaine.", false);
        yield return new WaitForSeconds(7);
        isabelleDial.ResetSentence();

        isabelleDial.SetSentence("J'étais dans ma cabine pendant le meurtre de mon Maurice.", false);
        yield return new WaitForSeconds(7);
        isabelleDial.ResetSentence();

        /*PIERRE*/

        pierreDial.SetSentence("Je suis Pierre. Le fils du Capitaine.", false);
        yield return new WaitForSeconds(7);
        pierreDial.ResetSentence();

        pierreDial.SetSentence("J'étais sur le pont avec Marie pendant le meurtre.", false);
        yield return new WaitForSeconds(7);
        pierreDial.ResetSentence();

        pierreDial.SetSentence("Nous étions en train de flirter. Vous savez nous sommes en couple.", false);
        yield return new WaitForSeconds(7);
        pierreDial.ResetSentence();

        /*JULIE*/
        julieDial.SetSentence("Je suis Julie, la fille du capitaine.", false);
        yield return new WaitForSeconds(7);
        julieDial.ResetSentence();

        julieDial.SetSentence("J'étais avec Paul, en train de nager dans la piscine pendant le meurtre.", false);
        yield return new WaitForSeconds(7);
        julieDial.ResetSentence();

        /*MARIE*/
        marieDial.SetSentence("Je suis Marie, la domestique.", false);
        yield return new WaitForSeconds(7);
        marieDial.ResetSentence();

        marieDial.SetSentence("Comme l'a dit Pierre, j'étais avec lui sur le pont quand tout ça est arrivé.", false);
        yield return new WaitForSeconds(7);
        marieDial.ResetSentence();

        /*LUIGI*/
        luigiDial.SetSentence("Gié souis Louigi, è gié souis en vacance.", false);
        yield return new WaitForSeconds(7);
        luigiDial.ResetSentence();

        luigiDial.SetSentence("Gi'été en trrrain dé discouter avéc Jean dans lé salon pendant lé méourrrtre.", false);
        yield return new WaitForSeconds(7);
        luigiDial.ResetSentence();

        /*JEAN*/

        jeanDial.SetSentence("Je m'appelle Jean, je suis Médecin.", false);
        yield return new WaitForSeconds(7);
        jeanDial.ResetSentence();

        jeanDial.SetSentence("Je profite de mes vacances pour faire une petite croisière paisible.", false);
        yield return new WaitForSeconds(7);
        jeanDial.ResetSentence();


    }


}
