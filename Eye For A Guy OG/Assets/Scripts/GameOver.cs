using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public Canvas gameOver;
    public Button retryBtn;
    public Button quitBtn;

	void Awake ()
    {
        gameOver = GetComponent<Canvas>();
        retryBtn = GetComponent<Button>();
        quitBtn = GetComponent<Button>();
        gameOver.enabled = false;
    }

    public void playerCaught ()
    {
        gameOver.enabled = true;
        Time.timeScale = 0;
    }

    public void Retry ()
    {
        gameOver.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit ()
    {
        SceneManager.LoadScene(0);
    }
	
}
