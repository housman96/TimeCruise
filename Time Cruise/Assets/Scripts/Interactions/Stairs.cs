using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Vector3 endPosition;
    public Vector3 teleportedPosition;
    public int sens;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger == false)
        {
            other.GetComponent<PlayerController>().setAnimation(endPosition, teleportedPosition, sens);
        }
    }
}
