using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

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
        if (popUpIndex == 0)
        {
            // checks whether any input of this specific button is received
            if (kb.gKey.wasPressedThisFrame)
            {
                baseTutorial.SetActive(false);
                ShowPopUp();
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            // checks whether any input of this specific button is received
            if (/*gp.leftStick.IsActuated() ||*/ kb.wKey.wasPressedThisFrame || kb.aKey.wasPressedThisFrame || kb.sKey.wasPressedThisFrame || kb.dKey.wasPressedThisFrame)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (/*gp.rightStick.IsActuated() ||*/ kb.iKey.wasPressedThisFrame || kb.jKey.wasPressedThisFrame || kb.kKey.wasPressedThisFrame || kb.lKey.wasPressedThisFrame)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (/*gp.rightTrigger.wasPressedThisFrame ||*/ kb.spaceKey.wasPressedThisFrame)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (/*gp.rightShoulder.wasPressedThisFrame ||*/ kb.qKey.wasPressedThisFrame)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (/*gp.leftTrigger.wasPressedThisFrame ||*/ kb.eKey.wasPressedThisFrame)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            if (/*gp.rightShoulder.wasPressedThisFrame ||*/ kb.qKey.wasPressedThisFrame)
            {
                ShowPopUp();
                popUpIndex++;
            }
        }
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

}
