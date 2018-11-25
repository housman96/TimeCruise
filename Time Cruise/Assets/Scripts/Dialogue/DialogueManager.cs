using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class DialogueManager : MonoBehaviour {

    public GameObject popup;
    public string characterName;

    public Text nameText;
    public Text sentenceText;

    private System.Random rng = new System.Random();
    private List<int> indexesAlea;
    private StringBuilder sentenceStringBuilder;
    private string currentSentence;
    private float rate;

    private bool encrypted = true;

    private Coroutine currentCoroutine;

    void Start()
    {
        nameText.text = characterName;
    }

    public void StartDialogue(string sentence, float rate)
    {
        currentSentence = sentence;
        DisplaySentenceLetters(rate);
    }

    public void StopDialogue()
    {
        HindPopUp();
    }

    private void DisplaySentenceLetters(float rate)
    {
        indexesAlea = new List<int>();
        for (int x = 0; x < currentSentence.Length; x++)
        {
            indexesAlea.Add(x);
        }
        Shuffle(indexesAlea);
        sentenceStringBuilder = new StringBuilder(new string(".".ToCharArray()[0], currentSentence.Length));
        UpdateDialogue(rate);
    }

    public void UpdateDialogue(float rate)
    {
        if(currentSentence == "")
        {
            HindPopUp();
            return;
        }
        if (encrypted)
        {
            this.rate = rate;
        }
        else
        {
            this.rate = 1.0f;
        }
        DisplayPopUp();
        currentCoroutine = StartCoroutine(UpdateText());
    }

    public void SetSentence(string sentence, bool encrypted)
    {
        StopAllCoroutines();
        this.currentSentence = sentence;
        this.encrypted = encrypted;
        DisplaySentenceLetters(0.0f);
    }

    public void ResetSentence()
    {
        currentSentence = "";
    }

    public void DisplayPopUp()
    {
        RectTransform popupTransform = popup.GetComponent<RectTransform>();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        screenPos += new Vector3(0, popupTransform.rect.height, 0);                 // TODO : Rajouter la taille du PNJ
        popupTransform.SetPositionAndRotation(screenPos, Quaternion.identity);
       
        popup.SetActive(true);
    }
    
    public void HindPopUp()
    {
        popup.SetActive(false);
    }

    IEnumerator UpdateText()
    {
        string tmpCurrent = currentSentence;
        int nbIdexToPrint = (int)Math.Floor(tmpCurrent.Length * rate);
        for (int c = 0; c < nbIdexToPrint; c++)
        {
            int index = indexesAlea[c];
            sentenceStringBuilder[index] = tmpCurrent[index];
        }
        sentenceText.text = sentenceStringBuilder.ToString();
        yield return null;
    }

    public void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}
