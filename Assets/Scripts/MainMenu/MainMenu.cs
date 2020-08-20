using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool flash;

    public GameObject lobby;
    public GameObject options;
    public GameObject credits;
    public GameObject mainMenu;
    public Sprite[] UiSprites;
    public GameObject[] UiImagesToChange;

    public Button StartButton;
    Gamepad gp;

    public Dropdown firstSelected;

    private bool notOnMainMenu;
    private bool onLobby;

    private void Start()
    {
        gp = InputSystem.GetDevice<Gamepad>();
    }
    private void Update()
    {
        if (notOnMainMenu)
        {
            if (!onLobby)
            {
                if(gp.buttonEast.wasPressedThisFrame)
                {
                    onLobby = false;
                    notOnMainMenu = false;
                    options.SetActive(false);
                    credits.SetActive(false);
                    lobby.SetActive(false);
                    mainMenu.SetActive(true);
                    for (int i = 0; i < UiSprites.Length; i++)
                    {
                        UiImagesToChange[i].GetComponent<Image>().sprite = UiSprites[i];
                    }
                    StartButton.Select();
                }
            }
            else if (onLobby)
            {
                if (PlayerManager.instance.GetPlayerConfigurations().All(p => p.IsReady == false))
                {
                    if (gp.buttonEast.wasPressedThisFrame)
                    {
                        onLobby = false;
                        notOnMainMenu = false;
                        options.SetActive(false);
                        credits.SetActive(false);
                        lobby.SetActive(false);
                        mainMenu.SetActive(true);
                        for (int i = 0; i < UiSprites.Length; i++)
                        {
                            UiImagesToChange[i].GetComponent<Image>().sprite = UiSprites[i];
                            Debug.Log(i);
                        }
                        StartButton.Select();
                    }
                }
                else { return; }
            }
        }
    }

    public void OpenLobby()
    {
        onLobby = true;
        lobby.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenOptions()
    {
        onLobby = false;
        options.SetActive(true);
        mainMenu.SetActive(false);
        notOnMainMenu = true;
    }

    public void OpenCredits()
    {
        onLobby = false;
        credits.SetActive(true);
        firstSelected.Select();
        mainMenu.SetActive(false);
        notOnMainMenu = true;
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
