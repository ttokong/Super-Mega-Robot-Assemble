using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReturnToMM : MonoBehaviour
{
    Gamepad gp;

    public bool returnToMM;

    public static bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        gp = InputSystem.GetDevice<Gamepad>();
    }

    void Update()
    {

        if (returnToMM)
        {
            SceneManager.LoadScene(0);
        }

        if (gameEnded)
        {
            Time.timeScale = 0;
            if (gp.buttonSouth.wasPressedThisFrame)
            {
                StartCoroutine(TutorialEnding());
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    IEnumerator TutorialEnding()
    {
        yield return new WaitForSeconds(0.5f);
        returnToMM = true;
    }

}
