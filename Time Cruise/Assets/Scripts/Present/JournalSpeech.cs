using System.Collections;
using UnityEngine;

public class JournalSpeech : MonoBehaviour
{
    public DialogueTrigger inspecteurDial;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(journalSpeech());
    }

    public IEnumerator journalSpeech()
    {
        inspecteurDial.SetSentence("Jean a écrit:", false);
        yield return new WaitForSeconds(4);
        inspecteurDial.ResetSentence();

        inspecteurDial.SetSentence("“ Malgré ce que les gens pensent, Paul semble complétement inoffensif. “", false);
        yield return new WaitForSeconds(6);
        inspecteurDial.ResetSentence();

        inspecteurDial.SetSentence("“ Il a déserté l’armée pendant la grande guerre.“", false);
        yield return new WaitForSeconds(6);
        inspecteurDial.ResetSentence();

        inspecteurDial.SetSentence("“ Il m’a d’ailleurs avoué que le Capitaine le faisait chanter en le menaçant de le dénoncer à l’état français. “", false);
        yield return new WaitForSeconds(6);
        inspecteurDial.ResetSentence();

        inspecteurDial.SetSentence("“ Paul a voulu s’expliquer avec le Capitaine sur ce sujet l’autre jour, mais le capitaine était saoul et a titubé contre l’horloge de son bureau, au point de s'assommer. “", false);
        yield return new WaitForSeconds(6);
        inspecteurDial.ResetSentence();
    }
}
