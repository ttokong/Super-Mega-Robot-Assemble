using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject[] healthBars;
    public GameObject[] characterIcons;
    public GameObject[] flash;

    public int playerID;

    public void TakeDamage()
    {
        StartCoroutine(FlashCo());
    }

    IEnumerator FlashCo()
    {
        flash[0].SetActive(true);
        flash[1].SetActive(true);
        yield return new WaitForSeconds(.05f);
        flash[0].SetActive(false);
        flash[1].SetActive(false);
        yield return new WaitForSeconds(.05f);
        flash[0].SetActive(true);
        flash[1].SetActive(true);
        yield return new WaitForSeconds(.05f);
        flash[0].SetActive(false);
        flash[1].SetActive(false);

    }

    public void SetIcon(int character)
    {

        switch (character)
        {
            case 2:
                characterIcons[8].SetActive(false);
                characterIcons[7].SetActive(true);
                characterIcons[6].SetActive(false);
                LevelManager.instance.HealthBars[2].playerID = 1;
                LevelManager.instance.UltimateBars[2].playerID = 1;

                characterIcons[5].SetActive(false);              
                characterIcons[4].SetActive(false);              
                characterIcons[3].SetActive(true);               
                LevelManager.instance.HealthBars[1].playerID = 0;
                LevelManager.instance.UltimateBars[1].playerID = 0;

                characterIcons[2].SetActive(true);               
                characterIcons[1].SetActive(false);              
                characterIcons[0].SetActive(false);              
                LevelManager.instance.HealthBars[0].playerID = 2;
                LevelManager.instance.UltimateBars[0].playerID = 2;
                break;                                           
                                                                 
                                                                 
            case 1:                                              
                characterIcons[8].SetActive(true);               
                characterIcons[7].SetActive(false);              
                characterIcons[6].SetActive(false);              
                LevelManager.instance.HealthBars[2].playerID = 2;
                LevelManager.instance.UltimateBars[2].playerID = 2;

                characterIcons[5].SetActive(false);              
                characterIcons[4].SetActive(false);              
                characterIcons[3].SetActive(true);               
                LevelManager.instance.HealthBars[1].playerID = 0;
                LevelManager.instance.UltimateBars[1].playerID = 0;

                characterIcons[2].SetActive(false);              
                characterIcons[1].SetActive(true);               
                characterIcons[0].SetActive(false);              
                LevelManager.instance.HealthBars[0].playerID = 1;
                LevelManager.instance.UltimateBars[0].playerID = 1;
                break;


            case 0:
                characterIcons[8].SetActive(false);
                characterIcons[7].SetActive(true);
                characterIcons[6].SetActive(false);
                LevelManager.instance.HealthBars[2].playerID = 1;
                LevelManager.instance.UltimateBars[2].playerID = 1;

                characterIcons[5].SetActive(true);
                characterIcons[4].SetActive(false);
                characterIcons[3].SetActive(false);
                LevelManager.instance.HealthBars[1].playerID = 2;
                LevelManager.instance.UltimateBars[1].playerID = 2;

                characterIcons[2].SetActive(false);
                characterIcons[1].SetActive(false);
                characterIcons[0].SetActive(true);
                LevelManager.instance.HealthBars[0].playerID = 0;
                LevelManager.instance.UltimateBars[0].playerID = 0;
                break;
        }
    }

    public void SetHealth(float health)
    {
        switch (health)
        {
            case 5:
                healthBars[4].SetActive(true);
                healthBars[3].SetActive(true);
                healthBars[2].SetActive(true);
                healthBars[1].SetActive(true);
                healthBars[0].SetActive(true);
                break;

            case 4:
                healthBars[4].SetActive(false);
                healthBars[3].SetActive(true);
                healthBars[2].SetActive(true);
                healthBars[1].SetActive(true);
                healthBars[0].SetActive(true);
                break;

            case 3:
                healthBars[4].SetActive(false);
                healthBars[3].SetActive(false);
                healthBars[2].SetActive(true);
                healthBars[1].SetActive(true);
                healthBars[0].SetActive(true);
                break;

            case 2:
                healthBars[4].SetActive(false);
                healthBars[3].SetActive(false);
                healthBars[2].SetActive(false);
                healthBars[1].SetActive(true);
                healthBars[0].SetActive(true);
                break;

            case 1:
                healthBars[4].SetActive(false);
                healthBars[3].SetActive(false);
                healthBars[2].SetActive(false);
                healthBars[1].SetActive(false);
                healthBars[0].SetActive(true);
                break;

            case 0:
                healthBars[4].SetActive(false);
                healthBars[3].SetActive(false);
                healthBars[2].SetActive(false);
                healthBars[1].SetActive(false);
                healthBars[0].SetActive(false);
                break;

        }
    }
}
