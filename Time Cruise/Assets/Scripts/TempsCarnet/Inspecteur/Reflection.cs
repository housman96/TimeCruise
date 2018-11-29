using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public Interactable interactable;
    public DialogueTrigger inspecteur;
    public string texte;
    public int temps = 4; 

    public void StartReflection()
    {
        StartCoroutine("Reflexion");
    }

    private IEnumerator Reflexion()
    {
        GameObject popup = null;
        if (interactable != null)
        {
            popup = interactable.popup;
            interactable.popup = null;
            interactable.enabled = false;
            popup.SetActive(false);
        }
        inspecteur.SetSentence("*" + texte + "*", false);
        yield return new WaitForSeconds(temps);
        inspecteur.ResetSentence();

        if (interactable != null)
        {
            interactable.enabled = true;
            interactable.popup = popup;
        }
    }
}
