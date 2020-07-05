using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryAndDefeatScreen : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject defeatScreen;


    public void NextChapter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RTMM()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
