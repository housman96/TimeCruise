using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text sentenceText;

    public Queue<string> sentences;
    public Animator animator;

    public KeyCode nextSentenceKey;

    private PlayerController playerController;
    [HideInInspector]
    public bool isDialoging = false;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        playerController = FindObjectOfType<PlayerController>();

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

    public void EndDialogue()
    {
        animator.SetBool("isChatting", false);
        isDialoging = false;
        playerController.UnlockMoves();
    }


}
