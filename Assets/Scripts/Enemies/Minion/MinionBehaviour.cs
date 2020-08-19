using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private EnemyController EC;

    public bool pulled = false;
    //public float pulledCD = 1f;

    private bool stuncdcalled = false;
    private bool bulletHitBufferCalled = false;
    //private bool pullcdcalled;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        EC = GetComponent<EnemyController>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        timer = Random.Range(0, 4);
        OGhealth = health;
        enemyHealthBar.SetMaxHealth(OGhealth);
        anim = GetComponent<Animator>();

        //multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();
        //multipleTargetCamera.targets.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();

        UpdateHealth();

        if (!stunned)
        {
            RngDecider();
        }

        if (stunned)
        {
            if (!stuncdcalled)
            {
                StartCoroutine(StunCD());
            }
        }

        if (bulletHit)
        {
            if (!bulletHitBufferCalled)
            {
                StartCoroutine(bulletHitBuffer());
            }
        }
        
        
        if (GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }


        /* if (pulled)
        {
            stunned = true;
            transform.position = Vector3.Lerp(transform.position, SK.VacuumPoint.transform.position, 1f);
            if (!pullcdcalled)
            {
                StartCoroutine(PullCD());
            }
        }*/
    }

    void RngDecider()
    {
        if(actionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenActions)
            {
                EC.LocateRandomTarget();
                actionID = Random.Range(0, 19);
                timer = Random.Range(0 , timeBetweenActions);         // randomly reduces wait time between each action by 0 to 3 seconds
                actionComplete = false;
            }
        }
        else if (!actionComplete)
        {
            ChangeAction(actionID);
        }

    }

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
        RPC_MoveToLocation(newPos);
    }

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
            RPC_Fire();
            shootTrig = false;
        }
    }

    // enemy shoots
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

    IEnumerator StunCD()
    {
        stuncdcalled = true;

        agent.isStopped = true;

        yield return new WaitForSeconds(stunnedCD);
        /*if (!agent.isStopped)
        {
            agent.isStopped = true;
        }*/

        stunned = false;
        stuncdcalled = false;
    }

    IEnumerator bulletHitBuffer()
    {
        bulletHitBufferCalled = true;

        yield return new WaitForSeconds(0.3f);
        bulletHit = false;

        bulletHitBufferCalled = false;
    }

    /*IEnumerator PullCD()
    {
        pullcdcalled = true;
        yield return new WaitForSeconds(pulledCD);
        pulled = false;
        pullcdcalled = false;
    }*/

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
}
