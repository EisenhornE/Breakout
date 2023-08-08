using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _highScoreText;
    private GameManager _gameManager;
    private int lastScoreMultiple = 0;

    void Start()
    {
        _scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score = 0;
        _scoreText.text = "Score: " + score;
        _gameManager = FindObjectOfType<GameManager>();
        _highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        _highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // As its name suggests, it adds scores based on what block is destroyed. The AddLife() function is also called here
    // every time the score reaches a hundred number (eg. 100, 200, 300, etc.).

    public void AddScore(int points)
    {
        score += points;
        _scoreText.text = "Score: " + score;

        // This line of code checks if the score reaches a multiple of 100
        int currentScoreMultiple = score / 100;

        if (currentScoreMultiple > lastScoreMultiple)
        {
            _gameManager.AddLife();
            Debug.Log("Added a life!");
            // This line of code updates the currentScoreMultiple value to make sure that it doesn't add a life again until it reaches
            // another 100.
            lastScoreMultiple = currentScoreMultiple;
        }
    }

    public void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            _highScoreText.text = "Highscore: " + score.ToString();
        }
    }
}
