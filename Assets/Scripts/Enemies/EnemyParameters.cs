using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class EnemyParameters : MonoBehaviour
{

    #region PhotonView

    [HideInInspector]
    public PhotonView PV;

    #endregion

    public bool followTarget;

    public float targetRadiusMin;
    public float targetRadiusMax;

    public float health;


    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public NavMeshAgent agent;

    [HideInInspector]
    public float OGhealth;

    [HideInInspector]
    public EnemyController ec;

    void Start()
    {

    }

    [PunRPC]
    public void RPC_TakeDamage(float dmg)
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

    public void DeathTrigger()
    {
        if (health <= 0)
        {
            PV.RPC("Dead", RpcTarget.All);
        }
    }

    [PunRPC]
    public void Dead()
    {
        Destroy(gameObject);
    }
}
