using UnityEngine;

public class RoomManager : MonoBehaviour
{

    bool isVisible = false;

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
        if (other.tag == "Player")
        {
            setRenderer(transform, other, true);
        }
        else if(other.tag == "Character")
        {
            other.GetComponent<Renderer>().enabled = isVisible;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            setRenderer(transform, other, false);
        }
    }



    void setRenderer(Transform obj, Collider2D other, bool visible)
    {
        isVisible = visible;
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
