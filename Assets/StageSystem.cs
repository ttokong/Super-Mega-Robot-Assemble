using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public GameObject Boss;
    public GameObject VictoryScreen;

    int PhaseCounter = 0;
    public static int MinionsKilled;

    void Start()
    {
        Boss.SetActive(false);
        VictoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PhaseCounter == 0 && MinionsKilled == 5)
        {
            EnterPhase1();
        }
        else if (PhaseCounter == 1 && MinionsKilled == 20)
        {
            EnterPhase2();
        }
        else if (PhaseCounter == 2 && Boss.GetComponent<BossBehaviour>().enraged == true)
        {
            EnterPhase3();
        }

    }

    void EnterPhase1()
    {
        PhaseCounter++;
        MinionsKilled = 0;
        MinionSpawner.minionSpawnRate = 1.5f;
    }

    void EnterPhase2()
    {
        PhaseCounter++;
        MinionsKilled = 0;
        Boss.SetActive(true);
    }

    void EnterPhase3()
    {
        if (Boss.GetComponent<BossBehaviour>().health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("BossDead");
            VictoryScreen.SetActive(true);
        }
    }
}
