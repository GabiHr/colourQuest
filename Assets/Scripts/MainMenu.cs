using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayOne()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void PlayTwo()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
