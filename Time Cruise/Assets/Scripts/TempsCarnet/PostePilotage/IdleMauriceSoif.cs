using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMauriceSoif : MonoBehaviour
{
    public DialogueTrigger Maurice;
    public DialogueTrigger Marie;

    public void StartIdle()
    {
        StartCoroutine(Dialogue());
    }

    public void Stop()
    {
        StopAllCoroutines();
        Maurice.ResetSentence();
        Marie.ResetSentence();
    }

    public IEnumerator Dialogue()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(10, 17));

            Maurice.SetSentence("Ha, je ferais n’importe quoi pour avoir un petit verre de rouge. Marie voudrais-tu bien me chercher une bouteille au bar.");
            yield return new WaitForSeconds(7);
            Maurice.ResetSentence();

            Marie.SetSentence("Non Monsieur, vous savez bien que Madame Isabelle m’a interdit de vous servir la moindre goutte d’alcool.");
            yield return new WaitForSeconds(7);
            Marie.ResetSentence();

            Maurice.SetSentence("Mais ma petite Marie, qui est le capitaine sur ce bateau? Moi ou ma femme?");
            yield return new WaitForSeconds(7);
            Maurice.ResetSentence();

            Marie.SetSentence("Sauf votre respect Monsieur, je préfères vous désobéir que de me mettre à dos votre femme.");
            yield return new WaitForSeconds(7);
            Marie.ResetSentence();
        }
    }
}
