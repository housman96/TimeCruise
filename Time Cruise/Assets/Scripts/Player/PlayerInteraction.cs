using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public float range;

    private DialogueManager dialogueManager;
    private Interactible[] availableInteractibles = new Interactible[8];
	
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    
	// Update is called less than once per frame
	void FixedUpdate () {

        int layerMask = LayerMask.GetMask("Interactable");
        RaycastHit2D[] rayHits = new RaycastHit2D[8];
        rayHits[0] = Physics2D.Raycast(transform.position, Vector2.up, range, layerMask);
        rayHits[1] = Physics2D.Raycast(transform.position, Vector2.down, range, layerMask);
        rayHits[2] = Physics2D.Raycast(transform.position, Vector2.left, range, layerMask);
        rayHits[3] = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
        rayHits[4] = Physics2D.Raycast(transform.position, Vector2.right + Vector2.up, range, layerMask);
        rayHits[5] = Physics2D.Raycast(transform.position, Vector2.right + Vector2.down, range, layerMask);
        rayHits[6] = Physics2D.Raycast(transform.position, Vector2.left + Vector2.up, range, layerMask);
        rayHits[7] = Physics2D.Raycast(transform.position, Vector2.left + Vector2.down, range, layerMask);

        Debug.DrawLine(transform.position, transform.position + Vector3.up * range);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * range);
        Debug.DrawLine(transform.position, transform.position + Vector3.left * range);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.right + Vector3.up).normalized * range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.right + Vector3.down).normalized * range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.left + Vector3.up).normalized * range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.left + Vector3.down).normalized * range);

        for (int x = 0; x< rayHits.Length; x++)
        {
            if (rayHits[x].collider != null)    // S'il y'a collision
            {
                Interactible interactible = rayHits[x].transform.GetComponent<Interactible>();
                availableInteractibles[x] = interactible;
            }
            else
            {
                availableInteractibles[x] = null;
            }
        }
	}
    

    void Update()
    {
        bool actionAvailable = false;
        Interactible interactible = null;
        for (int x = 0; x < availableInteractibles.Length; x++)
        {
            if(availableInteractibles[x] != null)
            {
                interactible = availableInteractibles[x];
                actionAvailable = true;
                break;
            }
        }
        if (actionAvailable && Input.GetKeyDown(interactible.actionKeyCode))
        {
            interactible.Interact();
        }
        if (dialogueManager.isDialoging && Input.GetKeyDown(dialogueManager.nextSentenceKey))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}
