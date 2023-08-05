using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    private GameObject _menuCanvas;

    void Start()
    {
        _menuCanvas = GameObject.Find("MenuCanvas");
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _menuCanvas.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
