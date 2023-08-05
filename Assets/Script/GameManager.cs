using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int Lives = 3;
    private TextMeshProUGUI _livesText;

    void Start()
    {
        _livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        _livesText.text = "Lives: " + Lives;
    }

    public void LoseLife()
    {
        Lives--;
        _livesText.text = "Lives: " + Lives;

        if (Lives == 0)
        {
            Debug.Log("Game Over");
            PlayerController playerController = FindObjectOfType<PlayerController>();
            playerController.enabled = false;
            playerController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void AddLife()
    {
        Lives++;
        _livesText.text = "Lives: " + Lives;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
