
using UnityEngine;

public class BlockDestruct : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ball")
        {
            Destroy(gameObject);
        }
    }
}
