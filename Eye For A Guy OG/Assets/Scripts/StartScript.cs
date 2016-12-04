using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScript : MonoBehaviour
{

    public Canvas mainMenu;
    public Button startBtn;
    public Button exitBtn;

    void Awake()
    {
        mainMenu = GetComponent<Canvas>();
        startBtn = GetComponent<Button>();
        exitBtn = GetComponent<Button>();
    }

    public void ClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

}