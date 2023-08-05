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
        switch (other.gameObject.tag)
        {
            case "RBlock":
                _scoreManager.AddScore(1);
                Destroy(other.gameObject);
                audioManager.Play("BlockDestruct");
                break;
            case "BBlock":
                _scoreManager.AddScore(5);
                Destroy(other.gameObject);
                audioManager.Play("BlockDestruct");
                break;
            case "GBlock":
                _scoreManager.AddScore(10);
                Destroy(other.gameObject);
                audioManager.Play("BlockDestruct");
                break;
            case "YBlock":
                _scoreManager.AddScore(15);
                Destroy(other.gameObject);
                audioManager.Play("BlockDestruct");
                break;
            case "PBlock":
                _scoreManager.AddScore(20);
                Destroy(other.gameObject);
                audioManager.Play("BlockDestruct");
                break;
        }
    }
}
