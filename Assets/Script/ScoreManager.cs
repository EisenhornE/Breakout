using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _highScoreText;
    private GameManager _gameManager;
    private bool isDivisibleby100;

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
    // every time the score reaches a number that is divisible by 100.

    public void AddScore(int points)
    {
        score += points;
        _scoreText.text = "Score: " + score;

        isDivisibleby100 = score % 100 == 0;

        if (isDivisibleby100 && score != 0)
        {
            _gameManager.AddLife();
            Debug.Log("Added a life!");
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
