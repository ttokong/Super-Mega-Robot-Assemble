using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : EnemyParameters
{
    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        OGhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();
    }
}
