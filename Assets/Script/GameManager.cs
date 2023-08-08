using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int Lives = 3;
    private TextMeshProUGUI _livesText;
    [SerializeField] private GameObject _menuCanvas;
    private AudioManager _audioManager;
    [SerializeField] private GameObject _GameOver;

    void Start()
    {
        _livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        _livesText.text = "Lives: " + Lives;
        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Self explanatory. This function is called in the BallLauncher script when the ball collides with the below the player platform.

    public void LoseLife()
    {
        Lives--;
        _livesText.text = "Lives: " + Lives;

        if (Lives == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    // This function is called in the ScoreManager script when the player's score is divisible by 100. This is so that
    // the player can have an extra chance to get a higher score.

    public void AddLife(int numLives = 1)
    {
        Lives += numLives;
        _livesText.text = "Lives: " + Lives;
    }

    // This Update() here is for when the player presses the Escape key, the game will pause and the menu will appear.
    // Pressing the Escape key again will resume the game. Time.timescale is used to pause the game. with 0 being paused
    // and 1 being normal speed. I can see this being used in a simulation game in the future

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                _menuCanvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                _menuCanvas.SetActive(false);
            }
            _audioManager.Play("Menu");
        }
        if (_GameOver == null)
            Debug.Log("Game Over is null");
    }

    // This is a coroutine that waits for 3 seconds before loading the Main Menu scene after the player loses all their lives.
    // This is to give the player a chance to see the Game Over screen and see their highscore.

    IEnumerator GameOver()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.enabled = false;
        playerController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _GameOver.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main Menu");
    }
}
