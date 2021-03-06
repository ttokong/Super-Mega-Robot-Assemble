﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{  
    public static bool gameIsPaused;

    public GameObject pauseMenu;

    public Button firstButton;

    private void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused)
        {
            Paused();
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void Paused()
    {
        pauseMenu.SetActive(true);
        firstButton.Select();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Lvl1");
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
