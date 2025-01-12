﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public string sentence;
    public DialogueManager dialogueManager;
    public float offest;
    private float distance;
    private float radius;
    private bool hasDistanceChanged;
    private CircleCollider2D triggerCollider;

    void Start()
    {
        triggerCollider = this.gameObject.GetComponent<CircleCollider2D>();
        radius = triggerCollider.radius;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        distance = Vector3.Distance(other.bounds.center, triggerCollider.bounds.center);
        float rate = (radius + offest) - distance / (radius + offest);
        if (rate < 0)
            rate = 0;
        TriggerDialogue(sentence, rate);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        float tmpDist = Vector3.Distance(other.bounds.center, triggerCollider.bounds.center);
        distance = tmpDist;
        float rate = (radius + offest) - distance / (radius + offest);
        if (rate < 0)
            rate = 0;
        if (rate > 1)
            rate = 1;
        UpdateDialogue(rate);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dialogueManager.StopDialogue();
    }


    private void TriggerDialogue(string sentence, float rate)
    {
        dialogueManager.StartDialogue(sentence, rate);
    }

    private void UpdateDialogue(float rate)
    {
        dialogueManager.UpdateDialogue(rate);
    }
    
    public void SetSentence(string sentence)
    {
        this.sentence = sentence;
        dialogueManager.SetSentence(this.sentence, true);
    }

    public void SetSentence(string sentence, bool encrypted)
    {
        this.sentence = sentence;
        dialogueManager.SetSentence(this.sentence, encrypted);
    }

    public void ResetSentence()
    {
        this.sentence = "";
        dialogueManager.ResetSentence();
    }
}
