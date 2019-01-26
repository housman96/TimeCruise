using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerOrderer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        }
        if (GetComponent<TilemapRenderer>())
        {
            GetComponent<TilemapRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        }
    }
}
