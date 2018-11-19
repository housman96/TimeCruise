using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    //public Dialogue dialogue;
    public List<Dialogue> dialogues;
    public Dialogue dialogueVide;
    public DialogueManager dialogueManager;

    public float offest;
    private float distance;
    private float radius;
    private bool hasDistanceChanged;
    private CircleCollider2D triggerCollider;
    private Dialogue currentDialogue;

    void Start()
    {
        triggerCollider = this.gameObject.GetComponent<CircleCollider2D>();
        radius = triggerCollider.radius;
        currentDialogue = dialogueVide;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        distance = Vector3.Distance(other.bounds.center, triggerCollider.bounds.center);
        float rate = (radius+offest) - distance / (radius+offest);
        if (rate < 0)
            rate = 0;
        TriggerDialogue(currentDialogue, rate);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        float tmpDist = Vector3.Distance(other.bounds.center, triggerCollider.bounds.center);
        if (distance != tmpDist)
        {
            distance = tmpDist;
        float rate = (radius+offest) - distance / (radius+offest);
            if (rate < 0)
                rate = 0;
            if (rate > 1)
                rate = 1;
            UpdateDialogue(rate);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dialogueManager.EndDialogue();
    }



    private void TriggerDialogue(Dialogue dialogue, float rate)
    {
        dialogueManager.StartDialogue(dialogue, rate);
    }

    private void UpdateDialogue(float rate)
    {
        dialogueManager.UpdateDialogue(rate);
    }

    public void setCurrentDialogue(int i) {
        if (i<0 || i >= dialogues.Count) {
            currentDialogue = dialogueVide;
        }
        else {
            currentDialogue = dialogues[i];
        }
    }

}
