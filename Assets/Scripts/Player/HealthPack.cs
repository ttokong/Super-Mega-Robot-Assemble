using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject Playerscript;

    public GameObject Pack;
    public bool PackSpawned;

    public float PackCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        // reference to playerstats script
        Playerscript.GetComponent<PlayerStats>();

        PackCoolDown = 0f;
        PackSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPack();

        if (PackCoolDown == 30f)
        {
            // decreases the cd by 1 per second
            PackCoolDown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Playerscript.GetComponent<PlayerStats>().health = +20f;
            PackSpawned = false;
            Pack.SetActive(false);
        }
    }

    void SpawnPack()
    {
        if (PackCoolDown == 0 && PackSpawned == false)
        {
            Pack.SetActive(true);
            PackSpawned = true;
            PackCoolDown = 30f;
        }
    }

}
