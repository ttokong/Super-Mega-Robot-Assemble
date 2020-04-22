using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyParameters : MonoBehaviour
{

    public bool followTarget;

    public float targetRadiusMin;
    public float targetRadiusMax;

    public float health;

    public float wanderTimer;

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public NavMeshAgent agent;

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
