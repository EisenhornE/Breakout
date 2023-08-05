using UnityEngine;

// This script is for the blocks that the ball will destroy. The blocks are tagged with their respective colors.

public class BlockDestruct : MonoBehaviour
{

    private ScoreManager _scoreManager;
    public AudioManager audioManager;


    void Start()
    {
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // I used switch case here instead of if-else to make it look more readable. I feel that there is a better way to do this.
    // I just don't know yet. The SaveHighScore() function is called here so that the player's score will be updated immediately
    // if the condition is right.

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
        _scoreManager.SaveHighScore();
    }
}
