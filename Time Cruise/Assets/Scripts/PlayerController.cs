using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public int speed;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float horizontalTranslation = horizontalInput * Time.deltaTime * speed;
        float verticalTranslation = verticalInput * Time.deltaTime * speed;

        Vector2 translation = new Vector3(horizontalTranslation, verticalTranslation);

        animator.SetFloat("xInput", horizontalInput);
        animator.SetFloat("yInput", verticalInput);
        
        transform.Translate(translation);
        
	}
    
}
