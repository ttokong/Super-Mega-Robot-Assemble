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

    public float timeBetweenActions;

    public bool actionComplete = true;

    public EnemyHealthBar enemyHealthBar;

    public bool stunned = false;
    public float stunnedCD = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        cam = Camera.main;
        PV = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
        timer = Random.Range(0, 4);
        OGhealth = health;
        enemyHealthBar.SetMaxHealth(OGhealth);
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();

        if (!stunned)
        {
            RngDecider();

            UpdateHealth();
        }

        if (stunned)
        {
            StartCoroutine(stunCD());
        }
    }

    void RngDecider()
    {
        if(actionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenActions)
            {
                PV.RPC("LocateRandomTarget", RpcTarget.All);
                actionID = Random.Range(0, 19);
                timer = Random.Range(0 , timeBetweenActions);         // randomly reduces wait time between each action by 0 to 3 seconds
                actionComplete = false;
            }
        }
        else if (!actionComplete)
        {
            PV.RPC("ChangeAction", RpcTarget.All, actionID);
        }

    }

    [PunRPC]
    void ChangeAction(int id)
    {
        if (id >= 0 && id <= 9)    //50% chance to wander
        {
            Wander();
        }
        else if (id >= 10 && id <= 14)    //25% chance to attack
        {
            Attack();
        }
        else if (id >= 15 && id <= 19)    //25% chance to follow target
        {
            Follow();
        }
        //add evade feature
        else
        {
            actionComplete = true;
        }
    }

    private void Wander()
    {
        agent.isStopped = false;
        Vector3 newPos = RandomNavSphere(transform.position, targetRadiusMax, -1);
        PV.RPC("RPC_MoveToLocation", RpcTarget.All, newPos);
    }

    [PunRPC]
    void RPC_MoveToLocation(Vector3 _pos)
    {
        agent.SetDestination(_pos);
        actionComplete = true;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;


        NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, layermask);

        return navHit.position;
    }

    void UpdateHealth()
    {
        enemyHealthBar.SetHealth(health);
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
        FindObjectOfType<AudioManager>().Play("LaserGun");
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

    IEnumerator stunCD()
    {
        yield return new WaitForSeconds(stunnedCD);
        stunned = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
}
