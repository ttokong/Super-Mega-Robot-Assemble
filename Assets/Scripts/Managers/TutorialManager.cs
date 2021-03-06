﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    bool tutorialEnd = false;
    bool bufferTime = false;

    public GameObject baseTutorial;

    Gamepad gp;

    Keyboard kb;

    // Start is called before the first frame update
    void Start()
    {
        gp = InputSystem.GetDevice<Gamepad>();

        kb = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
        // checks if tutorial just started
        // base
        if (popUpIndex == 0)
        {
            // checks whether any input of this specific button is received
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                baseTutorial.SetActive(false);
                ShowPopUp();
                popUpIndex++;
                StartCoroutine(BufferTimer());
            }
        }
        // tutorial 1
        if (popUpIndex == 1 && bufferTime)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
                bufferTime = false;
                StartCoroutine(BufferTimer());
            }
        }
        // tutorial 1.1
        if (popUpIndex == 2 && bufferTime)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
                bufferTime = false;
                StartCoroutine(BufferTimer());
            }
        }
        // tutorial 1.2
        if (popUpIndex == 3 && bufferTime)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
                bufferTime = false;
                StartCoroutine(BufferTimer());
            }
        }
        // tutorial 1.3
        if (popUpIndex == 4 && bufferTime)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
                bufferTime = false;
                StartCoroutine(BufferTimer());
            }
        }
        // tutorial 1.4
        if (popUpIndex == 5 && bufferTime)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 2
        else if (popUpIndex == 6)
        {
            if (gp.leftStick.IsActuated() /*|| kb.wKey.wasPressedThisFrame || kb.aKey.wasPressedThisFrame || kb.sKey.wasPressedThisFrame || kb.dKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 2.1
        if (popUpIndex == 7)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 3
        else if (popUpIndex == 8)
        {
            if (gp.rightStick.IsActuated() /*|| kb.iKey.wasPressedThisFrame || kb.jKey.wasPressedThisFrame || kb.kKey.wasPressedThisFrame || kb.lKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 3.1
        if (popUpIndex == 9)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 4
        else if (popUpIndex == 10)
        {
            if (gp.rightTrigger.wasPressedThisFrame /*|| kb.spaceKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 4.1
        if (popUpIndex == 11)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
                FillAbility();
            }
        }
        // tutorial 5
        else if (popUpIndex == 12)
        {
            if (gp.leftTrigger.wasPressedThisFrame /*|| kb.qKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 5.1
        if (popUpIndex == 13)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
                LevelManager.instance.transformBar.AddCharge(100f);
            }
        }
        // tutorial 6
        else if (popUpIndex == 14)
        {
            if (gp.rightShoulder.wasPressedThisFrame /*|| kb.eKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 6.1
        if (popUpIndex == 15)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 7
        else if (popUpIndex == 16)
        {
            if (gp.rightTrigger.wasPressedThisFrame /*|| kb.qKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial 7.1
        if (popUpIndex == 17)
        {
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        // tutorial END
        if (popUpIndex == 18)
        {
            StartCoroutine(TutorialEnding());
        }

        EndofTutorial();
    }

    void ShowPopUp()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            // activates current popup with that index
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            // disables the rest
            else
            {
                popUps[i].SetActive(false);
            }
        }
    }

    void EndofTutorial()
    {
        if (tutorialEnd == true)
        {
            if (gp.buttonEast.wasPressedThisFrame /*|| kb.fKey.wasPressedThisFrame*/)
            {
                SceneManager.LoadScene(0);
            }
            if (gp.buttonSouth.wasPressedThisFrame /*|| kb.gKey.wasPressedThisFrame*/)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void FillAbility()
    {
        foreach (PlayerStats player in FindObjectsOfType<PlayerStats>())
        {
            player.ultiCharge = 4;
        }
        foreach (UltimateCharge ub in LevelManager.instance.UltimateBars)
        {
            ub.SetUltimatePercentage(4);
        }
    }

    IEnumerator TutorialEnding()
    {
        yield return new WaitForSeconds(0.5f);
        tutorialEnd = true;
    }

    IEnumerator BufferTimer()
    {
        yield return new WaitForSeconds(0.5f);
        bufferTime = true;
    }

}
