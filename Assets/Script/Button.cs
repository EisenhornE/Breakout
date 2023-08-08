using UnityEngine.SceneManagement;
using UnityEngine;

// The codes here are self explanatory. This script must be either be dragged/placed in the GameManager or the Canvas. 
// I recommend that you choose based on the situation as this script can be found in my Start GameObject in the Main Menu scene.
// and in the Canvas GameObject in the Game scene.

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
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _menuCanvas.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StopAllCoroutines();
    }
}
