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
        julieDial.SetSentence("Nous étions en train de flirter. Vous savez nous sommes en couple.");
        yield return new WaitForSeconds(5);
        julieDial.ResetSentence();

        /*MARIE*/

        /*LUIGI*/

        /*JEAN*/


    }


}
