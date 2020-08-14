using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    Gamepad gp = InputSystem.GetDevice<Gamepad>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUpIndex; i++)
        {
            // activates current popup with that index
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            // disables the rest
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        // checks if tutorial just started
        if (popUpIndex == 0)
        {
            // checks whether any input of this specific button is received
            if (gp.leftStick.IsActuated() || (Input.GetKeyDown(KeyCode.A)))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (gp.rightStick.IsActuated() || (Input.GetKeyDown(KeyCode.A)))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (gp.rightTrigger.wasPressedThisFrame || (Input.GetKeyDown(KeyCode.A)))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (gp.rightShoulder.wasPressedThisFrame || (Input.GetKeyDown(KeyCode.A)))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (gp.leftTrigger.wasPressedThisFrame || (Input.GetKeyDown(KeyCode.A)))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (gp.rightShoulder.wasPressedThisFrame || (Input.GetKeyDown(KeyCode.A)))
            {
                popUpIndex++;
            }
        }
    }
}
