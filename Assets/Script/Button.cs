using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
