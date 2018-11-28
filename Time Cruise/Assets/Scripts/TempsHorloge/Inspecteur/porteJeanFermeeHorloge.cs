using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porteJeanFermeeHorloge : MonoBehaviour
{
    public DialogueTrigger inspecteur;

    public void StartPorteFermee()
    {
        StartCoroutine("PorteFermee");
    }

    private IEnumerator PorteFermee()
    {
        inspecteur.SetSentence("*Je ferais mieux de ne pas les déranger.*", false);
        yield return new WaitForSeconds(3);
        inspecteur.ResetSentence();
    }
}
