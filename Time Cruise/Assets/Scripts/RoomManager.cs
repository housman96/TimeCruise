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
        setRenderer(transform, other, true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        setRenderer(transform, other, false);
    }



    void setRenderer(Transform obj, Collider2D other, bool visible)
    {
        if (other.gameObject.GetComponent<PlayerController>().isInRoom != visible)
        {
            other.gameObject.GetComponent<PlayerController>().isInRoom = visible;
            setRendererRec(obj, visible);
        }
    }
    void setRendererRec(Transform obj, bool visible)
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
                setRendererRec(child.transform, visible);
            }

        }
    }

}
