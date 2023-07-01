using UnityEngine;

public class BlockDestruct : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
        }
    }
}
