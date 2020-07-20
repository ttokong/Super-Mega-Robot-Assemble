using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenu;

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

    void Resume()
    {
        pauseMenu.SetActive(false);
    }

    void Paused()
    {
        pauseMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        Debug.Log("Left Room");
        PhotonRoom.room.playersInRoom--;
        PhotonNetwork.LeaveRoom();
    }
}
