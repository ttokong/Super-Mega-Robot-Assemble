using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject Pack;
    public bool PackSpawned;

    public int heal;
    public float PackCoolDown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        PackSpawned = false;
        timer = PackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPack();

        if (timer <= PackCoolDown && PackSpawned == false)
        {
            timer += Time.deltaTime;
        }
    }

    /* void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("fjksubh");
            Playerscript.GetComponent<PlayerStats>().health = +20f;
            PackSpawned = false;
            Pack.SetActive(false);
        }
    } */

    // triggers when its child object detects ontriggerenter
    public void PullTrigger(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerStats>().health < other.GetComponent<PlayerStats>().OGhealth)
            {
                other.GetComponent<PlayerStats>().RPC_PlayerHeal(heal);
                Pack.SetActive(false);
                PackSpawned = false;
            }
        }
    }

    void SpawnPack()
    {
        if (timer > PackCoolDown && PackSpawned == false)
        {
            Pack.SetActive(true);
            PackSpawned = true;
            timer = 0;
        }
    }

}
