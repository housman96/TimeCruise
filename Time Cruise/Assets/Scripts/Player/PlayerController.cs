using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public int speed;
    private bool isLocked = false;
    private bool isAnimation = false;
    private Vector3 endAnimation;
    private Vector3 teleportationAnimation;
    private int sensAnimation;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAnimation)
        {
            float step = speed * Time.deltaTime;
            animator.SetFloat("xInput", sensAnimation);
            transform.position = Vector3.MoveTowards(transform.position, endAnimation, step);
            if (transform.position == endAnimation)
            {
                transform.position = teleportationAnimation;
                isAnimation = false;
            }
        }
        else
        {
            if (!isLocked)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                float horizontalTranslation = horizontalInput * Time.deltaTime * speed;
                float verticalTranslation = verticalInput * Time.deltaTime * speed;

                Vector2 translation = new Vector3(horizontalTranslation, verticalTranslation);

                animator.SetFloat("xInput", horizontalInput);
                animator.SetFloat("yInput", verticalInput);

                transform.Translate(translation);
            }
            else
            {
                animator.SetFloat("xInput", 0); // Stop les animations quand on est lock
                animator.SetFloat("yInput", 0);
            }
        }

    }

    public void LockMoves()
    {
        isLocked = true;
    }

    public void UnlockMoves()
    {
        isLocked = false;
    }

    public void setAnimation(Vector3 v, Vector3 v2, int sens)
    {
        sensAnimation = sens;
        isAnimation = true;
        endAnimation = v;
        teleportationAnimation = v2;
    }
}
