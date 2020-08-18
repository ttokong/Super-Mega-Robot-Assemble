using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionParameters
{
    public bool followTarget;

    public float targetRadiusMin;
    public float targetRadiusMax;

    public bool bulletHit = false;

    public int health;

    //[HideInInspector]
    //public MultipleTargetCamera multipleTargetCamera;

    //[HideInInspector]
    //public SupportSkill sk;

    [HideInInspector]
    public Camera cam;


    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public NavMeshAgent agent;

    [HideInInspector]
    public int OGhealth;

    [HideInInspector]
    public EnemyController ec;

    public void RPC_TakeDamage(int dmg)
    {
        health -= dmg;
    }

    // private bool BTswitch = false;

    /* public void DeathTrigger()
    {
        if (health <= 0)
        {
            Dead();
        }

        /*if (bulletHit == true && BTswitch == false)
        {
            StartCoroutine(bulletTrigger());
        }
    } */



    /*IEnumerator bulletTrigger()
    {
        BTswitch = true;
        yield return new WaitForSeconds(1f);
        bulletHit = false;
        BTswitch = false;
    }*/

}
