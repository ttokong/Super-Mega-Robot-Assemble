using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HealthPack : MonoBehaviour
{
    public GameObject Pack;
    public bool PackSpawned;

    public float heal;
    public float PackCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        heal = 20f;
        PackCoolDown = 0f;
        PackSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPack();

        if (PackCoolDown <= 31f && PackSpawned == false)
        {
            // decreases the cd by 1 per second
            PackCoolDown -= Time.deltaTime;
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
        other.GetComponent<PhotonView>().RPC("RPC_PlayerHeal", RpcTarget.All, heal);
        Pack.SetActive(false);
        PackSpawned = false;
    }

    void SpawnPack()
    {
        if (PackCoolDown <= 0 && PackSpawned == false)
        {
            Pack.SetActive(true);
            PackSpawned = true;
            PackCoolDown = 30f;
        }
    }

}
