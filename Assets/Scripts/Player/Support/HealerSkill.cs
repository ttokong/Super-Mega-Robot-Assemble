using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSkill : MonoBehaviour
{
    public GameObject HealingRadius;
    public int heal;
    PlayerStats playerstats;

    // Start is called before the first frame update
    void Start()
    {
        HealingRadius.SetActive(false);
        playerstats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PullTrigger(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerStats>().health < other.GetComponent<PlayerStats>().OGhealth)
            {
                other.GetComponent<PlayerStats>().RPC_PlayerHeal(heal);
            }
        }
    }

    public void Healing()
    {
        StartCoroutine(StartHeal());
    }

    IEnumerator StartHeal()
    {
        HealingRadius.SetActive(true);
        yield return new WaitForSeconds(.2f);
        HealingRadius.SetActive(false);
    }
}
