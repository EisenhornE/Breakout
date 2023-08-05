using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    private TextMeshProUGUI _scoreText;
    private GameManager _gameManager;
    private bool isDivisibleby100;

    void Start()
    {
        _scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score = 0;
        _scoreText.text = "Score: " + score;
        _gameManager = FindObjectOfType<GameManager>();
    }

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
}
