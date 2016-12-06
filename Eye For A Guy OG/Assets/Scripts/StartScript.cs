using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScript : MonoBehaviour {
    
    public Button startBtn;
    public Button exitBtn;

	void Awake ()
    {
        startBtn = GetComponent<Button>();
        exitBtn = GetComponent<Button>();
    }

    public void startPress ()
    {
        SceneManager.LoadScene(1);
    }

    public void exitPress ()
    {
        Application.Quit();
    }
}
