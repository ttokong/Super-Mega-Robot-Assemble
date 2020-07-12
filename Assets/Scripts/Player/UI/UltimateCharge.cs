using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateCharge : MonoBehaviour
{
    public GameObject[] ultBars;

    public int playerID;

    public void SetUltimatePercentage(int ultiPercentage)
    {
        switch (ultiPercentage)
        {
            case 4:
                ultBars[3].SetActive(true);
                ultBars[2].SetActive(true);
                ultBars[1].SetActive(true);
                ultBars[0].SetActive(true);
                break;

            case 3:
                ultBars[3].SetActive(false);
                ultBars[2].SetActive(true);
                ultBars[1].SetActive(true);
                ultBars[0].SetActive(true);
                break;

            case 2:
                ultBars[3].SetActive(false);
                ultBars[2].SetActive(false);
                ultBars[1].SetActive(true);
                ultBars[0].SetActive(true);
                break;

            case 1:
                ultBars[3].SetActive(false);
                ultBars[2].SetActive(false);
                ultBars[1].SetActive(false);
                ultBars[0].SetActive(true);
                break;

            case 0:
                ultBars[3].SetActive(false);
                ultBars[2].SetActive(false);
                ultBars[1].SetActive(false);
                ultBars[0].SetActive(false);
                break;
        }
    }
}
