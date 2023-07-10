using UnityEngine;

public class BlockDestruct : MonoBehaviour
{

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BBlock")
        {
            _gameManager.AddScore(5);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "RBlock")
        {
            _gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "GBlock")
        {
            _gameManager.AddScore(10);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "YBlock")
        {
            _gameManager.AddScore(15);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "PBlock")
        {
            _gameManager.AddScore(20);
            Destroy(other.gameObject);
        }
    }
}
