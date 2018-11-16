using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text sentenceText;

    public Queue<string> sentences;
    public Animator animator;

    public KeyCode nextSentenceKey;

    private PlayerController playerController;
    [HideInInspector]
    public bool isDialoging = false;

    private System.Random rng = new System.Random();
    private List<int> indexesAlea;
    private StringBuilder sentenceStringBuilder;
    private string currentSentence;

    private float rate;

    void Start () {
        sentences = new Queue<string>();
        playerController = FindObjectOfType<PlayerController>();

    }

    public void StartDialogue(Dialogue dialogue, float distanceRate)
    {
        isDialoging = true;
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        animator.SetBool("isChatting", true);
        DisplayNextSentenceLetters(distanceRate);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerController.LockMoves();
        isDialoging = true;

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        animator.SetBool("isChatting", true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        sentenceText.text = sentence;
    }

    void DisplayNextSentenceLetters(float rate)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        currentSentence = sentences.Dequeue();

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
        this.rate = rate;
        StartCoroutine(UpdateText());
    }

    IEnumerator UpdateText()
    {
        int nbIdexToPrint = (int)Math.Floor(currentSentence.Length * rate);
        for (int c = 0; c < nbIdexToPrint; c++)
        {
            int index = indexesAlea[c];
            sentenceStringBuilder[index] = currentSentence[index];
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

    public void EndDialogue()
    {
        animator.SetBool("isChatting", false);
        isDialoging = false;
        playerController.UnlockMoves();
    }


}
