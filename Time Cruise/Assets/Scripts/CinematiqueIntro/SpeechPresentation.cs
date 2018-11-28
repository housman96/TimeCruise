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
        matelotDial.SetSentence("Mesdames et Messieurs veuillez vous présenter à l'Inspecteur.");
        yield return new WaitForSeconds(3);
        matelotDial.ResetSentence();


        /*ISABELLE*/
        isabelleDial.SetSentence("Je suis Isabelle. La femme, enfin la veuve du Capitaine.");
        yield return new WaitForSeconds(5);
        isabelleDial.ResetSentence();

        isabelleDial.SetSentence("J'étais dans ma cabine pendant le meurtre de mon Maurice.");
        yield return new WaitForSeconds(5);
        isabelleDial.ResetSentence();

        /*PIERRE*/

        pierreDial.SetSentence("Je suis Pierre. Le fils du Capitaine.");
        yield return new WaitForSeconds(5);
        pierreDial.ResetSentence();

        pierreDial.SetSentence("J'étais sur le pont avec Marie pendant le meurtre.");
        yield return new WaitForSeconds(5);
        pierreDial.ResetSentence();

        pierreDial.SetSentence("Nous étions en train de flirter. Vous savez nous sommes en couple.");
        yield return new WaitForSeconds(5);
        pierreDial.ResetSentence();

        /*JULIE*/
        julieDial.SetSentence("Je suis Julie, la fille du capitaine.");
        yield return new WaitForSeconds(5);
        julieDial.ResetSentence();

        julieDial.SetSentence("J'étais avec Paul, en train de nager dans la piscine pendant le meurtre.");
        yield return new WaitForSeconds(5);
        julieDial.ResetSentence();

        /*MARIE*/
        marieDial.SetSentence("Je suis Marie, la domestique.");
        yield return new WaitForSeconds(5);
        marieDial.ResetSentence();

        marieDial.SetSentence("Comme l'a dit Pierre, j'étais avec lui sur le pont quand tous ça est arrivé.");
        yield return new WaitForSeconds(5);
        marieDial.ResetSentence();

        /*LUIGI*/
        luigiDial.SetSentence("Gié souis Louigi, è gié souis en vacance.");
        yield return new WaitForSeconds(5);
        luigiDial.ResetSentence();

        luigiDial.SetSentence("Gi'été en trrrain dé discouter avéc Jean dans lé salon pendant lé méourrrtre.");
        yield return new WaitForSeconds(5);
        luigiDial.ResetSentence();

        /*JEAN*/

        jeanDial.SetSentence("Je m'appelle Jean, je suis Médecin.");
        yield return new WaitForSeconds(5);
        jeanDial.ResetSentence();

        jeanDial.SetSentence("Je profite de mes vacances pour faire une petite croisière paisible.");
        yield return new WaitForSeconds(5);
        jeanDial.ResetSentence();


    }


}
