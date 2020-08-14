using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool flash;

    public GameObject lobby;
    public GameObject options;
    public GameObject credits;
    public GameObject mainMenu;

    public void OpenLobby()
    {
        lobby.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenOptions()
    {
        options.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator FlashCOStart(int secs)
    {
        yield return new WaitForSeconds(secs);
        OpenLobby();
        GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerManager>().ActivateScript();
    }

    public IEnumerator FlashCOOptions(int secs)
    {
        yield return new WaitForSeconds(secs);
        OpenOptions();
    }

    public IEnumerator FlashCOCredits(int secs)
    {
        yield return new WaitForSeconds(secs);
        OpenCredits();

    }

    public void FlashStart(int sec)
    {
        if (!flash)
        {
            StartCoroutine(FlashCOStart(sec));
        }
        else if (flash)
            return;
    }

    public void FlashOptions(int sec)
    {
        if (!flash)
        {
            StartCoroutine(FlashCOOptions(sec));
        }
        else if (flash)
            return;
    }

    public void FlashCredits(int sec)
    {
        if (!flash)
        {
            StartCoroutine(FlashCOCredits(sec));
        }
        else if (flash)
            return;
    }

    public void BTMM()
    {
        flash = false;
    }
}
