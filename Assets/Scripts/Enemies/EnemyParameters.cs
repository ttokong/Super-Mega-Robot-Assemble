using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameters : MonoBehaviour
{

    public float health;

    [HideInInspector]
    public float OGhealth;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void DeathTrigger()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
