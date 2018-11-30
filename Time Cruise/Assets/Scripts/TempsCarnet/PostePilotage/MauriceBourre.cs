using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MauriceBourre : MonoBehaviour
{
    public DialogueTrigger Maurice;
    public DialogueTrigger Marie;
    public DialogueTrigger Matelot;
    public UnityEvent OnMauricePart;
    public UnityEvent OnMariePart;
    public UnityEvent OnEnd;

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        yield return null;

        Maurice.SetSentence("Ha merci inspecteur, j’en avais bien besoin.");
        yield return new WaitForSeconds(3);
        Maurice.ResetSentence();

        Maurice.SetSentence("*Glou*");
        yield return new WaitForSeconds(0.2f);
        Maurice.ResetSentence();

        Maurice.SetSentence("   *Glou*");
        yield return new WaitForSeconds(0.2f);
        Maurice.ResetSentence();

        Maurice.SetSentence("       *Glou*");
        yield return new WaitForSeconds(0.2f);
        Maurice.ResetSentence();

        Maurice.SetSentence("           *Glou*");
        yield return new WaitForSeconds(0.2f);
        Maurice.ResetSentence();

        Maurice.SetSentence("HIC! Ha Marie je me sens d’humeur, romant.. HIC! Ne voudrais-tu pas m’aider à rejoindre ma cabine, histoire d’y discuter plus en privé?");
        yield return new WaitForSeconds(7);
        Maurice.ResetSentence();

        Marie.SetSentence("Je pense effectivement que vous devriez rejoindre votre cabine pour vous reposer. Mais vous allez devoir y aller seul Monsieur. Je suis attendue autre part.");
        yield return new WaitForSeconds(8);
        Marie.ResetSentence();

        Maurice.SetSentence("Oh, tant-pis, de toute manière je me sens très fatigué. HIC! Matelot à vous de piloter ce navire.");
        yield return new WaitForSeconds(6);
        Maurice.ResetSentence();
        OnMauricePart.Invoke();

        yield return new WaitForSeconds(1);
        OnMariePart.Invoke();

        Matelot.SetSentence("Moi? Piloter? Mais je ne sais pas piloter! Vite, je dois aller chercher Paul.");
        yield return new WaitForSeconds(2);
        OnEnd.Invoke();
        yield return new WaitForSeconds(5);
        Matelot.ResetSentence();
    }
}
