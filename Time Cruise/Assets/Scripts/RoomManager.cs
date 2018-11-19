using UnityEngine;

public class RoomManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        setRenderer(transform, true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        setRenderer(transform, false);
    }



    void setRenderer(Transform obj, bool visible)
    {
        foreach (Transform child in obj)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer)
            {
                renderer.enabled = visible;
            }
            else
            {
                setRenderer(child.transform, visible);
            }

        }
    }

}
