using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public float range;

    private bool isInteracting = false;
    private Interactible[] tmpInteractibles = new Interactible[8];
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D[] rayHits = new RaycastHit2D[8];
        rayHits[0] = Physics2D.Raycast(transform.position, Vector2.up, range);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * range);

        rayHits[1] = Physics2D.Raycast(transform.position, Vector2.down, range);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * range);

        rayHits[2] = Physics2D.Raycast(transform.position, Vector2.left, range);
        Debug.DrawLine(transform.position, transform.position + Vector3.left * range);

        rayHits[3] = Physics2D.Raycast(transform.position, Vector2.right, range);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * range);


        // Optional
        rayHits[4] = Physics2D.Raycast(transform.position, Vector2.right + Vector2.up, range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.right + Vector3.up).normalized * range);

        rayHits[5] = Physics2D.Raycast(transform.position, Vector2.right + Vector2.down, range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.right + Vector3.down).normalized * range);

        rayHits[6] = Physics2D.Raycast(transform.position, Vector2.left + Vector2.up, range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.left + Vector3.up).normalized * range);

        rayHits[7] = Physics2D.Raycast(transform.position, Vector2.left + Vector2.down, range);
        Debug.DrawLine(transform.position, transform.position + (Vector3.left + Vector3.down).normalized * range);


        for (int x = 0; x< rayHits.Length; x++)
        {
            if (rayHits[x].collider != null)    // S'il y'a collision
            {
                Interactible interactible = rayHits[x].transform.GetComponent<Interactible>();
                if (interactible != tmpInteractibles[x])    // Si l'interactible a changé 
                {
                    if (interactible != null)
                    {
                        Debug.Log(interactible.name);
                        Debug.DrawLine(transform.position, interactible.transform.position, Color.green);
                    }

                    DialogueTrigger dialogueTrigger = rayHits[x].transform.GetComponent<DialogueTrigger>();
                    if (dialogueTrigger != null)
                    {
                        if (!isInteracting)
                        {
                            dialogueTrigger.TriggerDialogue();
                            isInteracting = true;
                        }
                    }
                    
                }
                tmpInteractibles[x] = interactible;
            }
            else
            {
                tmpInteractibles[x] = null;
            }
        }
	}

    public void stopInteracting()
    {
        isInteracting = false;
    }
}
