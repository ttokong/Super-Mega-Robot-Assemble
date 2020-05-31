using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class MinionBehaviour : EnemyParameters
{
    private float timer;
    private float attTimer;

    private int actionID;


    public float attackTimer;

    public float actionTimer;

    public bool actionComplete = true;



    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        PV = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
        timer = actionTimer;
        attTimer = attackTimer;
        OGhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();
        ChangeAction();
    }

    void ChangeAction()
    {
        if(actionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= actionTimer)
            {
                actionID = Random.Range(0, 19);
                timer = Random.Range(0 , 4);         // randomly reduces wait time between each action by 0 to 3 seconds
                actionComplete = false;
            }
        }
        else if (!actionComplete)
        {
            if (actionID >= 0 && actionID <= 9)    //50% chance to wander
            {
                Wander();
            }
            else if (actionID >= 10 && actionID <= 14)    //25% chance to attack
            {
                Attack();
            }
            else if (actionID >= 15 && actionID <= 19)    //25% chance to follow target
            {
                Follow();
            }
            else
            {
                actionComplete = true;
            }
        }

    }

    private void Wander()
    {
        agent.isStopped = false;
        Vector3 newPos = RandomNavSphere(transform.position, targetRadiusMax, -1);
        agent.SetDestination(newPos);
        actionComplete = true;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;


        NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, layermask);

        return navHit.position;
    }


    private void Attack()
    {
        attTimer += Time.deltaTime;
        StartCoroutine(Shoot());
        agent.isStopped = true;
        RotateToTarget();

        if (attTimer >= attackTimer)
        {
            attTimer = 0;
            timer = 0;
            actionComplete = true;
        }
    }

    //face player
    private void RotateToTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
    }



    //Attack

    private bool shootTrig;
    public float firerate;
    public GameObject enemyBullet;
    public GameObject firePoint;

    IEnumerator Shoot()
    {
        if (shootTrig == false)
        {
            shootTrig = true;
            yield return new WaitForSeconds(1 / firerate);
            PV.RPC("RPC_Fire", RpcTarget.All);
            shootTrig = false;
        }
    }

    
    [PunRPC]
    private void RPC_Fire()
    {
        Instantiate(enemyBullet, firePoint.transform.position, transform.rotation);
    }

    //Follows Player
    private float followTimer;

    private void Follow()
    {
        followTimer += Time.deltaTime;
        agent.isStopped = false;
        followTarget = true;
        if (followTarget)
        {
            if (followTimer >= 3)
            {
                followTimer = Random.Range(0, 3);
                followTarget = false;
                actionComplete = true;
            }
        }
        else
            return; 
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
}
