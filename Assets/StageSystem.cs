using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public GameObject Boss;
    public GameObject VictoryScreen;
    public GameObject Text0;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;

    int PhaseCounter = 0;
    public static int MinionsKilled;

    void Start()
    {
        Boss.SetActive(false);
        VictoryScreen.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PhaseCounter == 0 && MinionsKilled == 5)
        {
            StartCoroutine(Phase1());
            EnterPhase1();
        }
        else if (PhaseCounter == 1 && MinionsKilled == 20)
        {
            StartCoroutine(Phase2());
            EnterPhase2();
        }
        else if (PhaseCounter == 2 && Boss.GetComponent<BossBehaviour>().enraged == true)
        {
            StartCoroutine(Phase3());
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


    IEnumerator Phase0()
    {
        Time.timeScale = 0;
        Text0.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        Text0.SetActive(false);
    }

    IEnumerator Phase1()
    {
        Time.timeScale = 0;
        Text1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        Text1.SetActive(false);
    }

    IEnumerator Phase2()
    {
        Time.timeScale = 0;
        Text2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        Text2.SetActive(false);
    }

    IEnumerator Phase3()
    {
        Time.timeScale = 0;
        Text3.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        Text3.SetActive(false);
    }
}
