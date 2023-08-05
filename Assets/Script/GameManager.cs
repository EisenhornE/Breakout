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

    public void LoseLife()
    {
        Lives--;
        _livesText.text = "Lives: " + Lives;

        if (Lives == 0)
        {
            StartCoroutine(GameOver());
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
