using UnityEngine;

public class MapManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        rendererOff(transform);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void rendererOff(Transform obj)
    {
        foreach (Transform child in obj)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer)
            {
                renderer.enabled = false;
            }
            else
            {
                rendererOff(child.transform);
            }

        }
    }
}
