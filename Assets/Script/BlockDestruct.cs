using UnityEngine;

public class BlockDestruct : MonoBehaviour
{

    private ScoreManager _scoreManager;
    public AudioManager audioManager;

    void Start()
    {
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BBlock")
        {
            _scoreManager.AddScore(5);
            audioManager.Play("BlockDestruct");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "RBlock")
        {
            _scoreManager.AddScore(1);
            audioManager.Play("BlockDestruct");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "GBlock")
        {
            _scoreManager.AddScore(10);
            audioManager.Play("BlockDestruct");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "YBlock")
        {
            _scoreManager.AddScore(15);
            audioManager.Play("BlockDestruct");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "PBlock")
        {
            _scoreManager.AddScore(20);
            audioManager.Play("BlockDestruct");
            Destroy(other.gameObject);
        }
    }
}
