using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public Canvas gameOverScreen;
    public Button retryBtn;
    public Button quitBtn;
    public Canvas winScreen;

    void Awake()
    {
        gameOverScreen.enabled = false;
        winScreen.enabled = false;
    }

    public void playerCaught()
    {
        gameOverScreen.enabled = true;
        Time.timeScale = 0;
    }

    public void victoryCondition()
    {
        winScreen.enabled = true;
        Time.timeScale = 0;
    }

    public void retryPress()
    {
        SceneManager.LoadScene(1);
        gameOverScreen.enabled = false;
        Time.timeScale = 1;
    }

    public void quitPress()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
