using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

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
            if(Input.GetAxis("Move") != 0)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetAxis("Aim") != 0)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetAxis("ShootHold") != 0)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetAxis("Ultimate") != 0)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (Input.GetAxis("Super Mega Robot Assemble") != 0)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetAxis("Ultimate") != 0)
            {
                popUpIndex++;
            }
        }
    }
}
