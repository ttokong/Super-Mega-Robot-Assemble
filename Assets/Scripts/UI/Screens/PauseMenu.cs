using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }

    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }

    void Paused()
    {
        pauseMenu.SetActive(true);
        gameIsPaused = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
