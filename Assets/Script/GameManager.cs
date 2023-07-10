using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score = 0;
        _scoreText.text = "Score: " + score;
    }

    public void AddScore(int points)
    {
        score += points;
        _scoreText.text = "Score: " + score;
    }
}
