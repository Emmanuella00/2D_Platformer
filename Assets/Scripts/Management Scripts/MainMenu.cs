using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public void PlayGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("GameScene-ALU");
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}
