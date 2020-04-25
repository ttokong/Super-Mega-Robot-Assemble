using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossBehaviour : EnemyParameters
{
    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        PV = GetComponent<PhotonView>();
        OGhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();
    }
}
