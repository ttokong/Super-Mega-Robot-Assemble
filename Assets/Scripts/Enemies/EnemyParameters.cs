using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyParameters : MonoBehaviour
{


    public bool followTarget;

    public float targetRadiusMin;
    public float targetRadiusMax;

    public bool bulletHit = false;

    public int health;

    //[HideInInspector]
    //public MultipleTargetCamera multipleTargetCamera;

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

    void Start()
    {

    }

    public void RPC_TakeDamage(int dmg)
    {
        if (gameObject.GetComponent<BossBehaviour>())
        {
            if (gameObject.GetComponent<BossCharge>().charging == false)
            {
                health -= dmg;
            }
        }
        else
        {
            health -= dmg;
        }

    }

    // private bool BTswitch = false;

    public void DeathTrigger()
    {
        if (health <= 0)
        {
            Dead();
        }

        /*if (bulletHit == true && BTswitch == false)
        {
            StartCoroutine(bulletTrigger());
        }*/

    }

    public void Dead()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Destroy(gameObject);
        //multipleTargetCamera.targets.Remove(gameObject.transform);
    }

    /*IEnumerator bulletTrigger()
    {
        BTswitch = true;
        yield return new WaitForSeconds(1f);
        bulletHit = false;
        BTswitch = false;
    }*/

}
