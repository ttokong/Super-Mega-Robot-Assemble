using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : EnemyParameters
{
    public bool enraged = false;
    public bool enragedCharging = false;

    private int actionID;

    private float timer;
    public float timeBetweenAttacks;

    public bool actionComplete = true;

    public BossHealthBar bossHealthBar;
    private EnemyController EC;

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        EC = GetComponent<EnemyController>();
        cam = Camera.main;
        timer = Random.Range(0, 4);
        agent = GetComponent<NavMeshAgent>();
        OGhealth = health;
        bossHealthBar.SetMaxHealth(OGhealth);

        //multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();
        //multipleTargetCamera.targets.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();

        if (!enragedCharging)
        {
            RngDecider();
        }

        UpdateHealth();

        EnragedCheck();
    }

    void RngDecider()
    {
        if (actionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks)
            {
                EC.LocateRandomTarget();
                actionID = Random.Range(0, 17);
                timer = Random.Range(0, 4);         // randomly reduces wait time between each action by 0 to 3 seconds
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
        if (id >= 0 && id <= 5)    //33.33% chance to wander
        {
            Wander();
        }
        else if (id >= 6 && id <= 11)    //33.33% chance to ground slam
        {
            gameObject.GetComponent<BossGroundSlam>().Slam();
        }
        else if (id >= 12 && id <= 17)    //33.33% chance to charge
        {
            gameObject.GetComponent<BossCharge>().Charge();
        }
        else
        {
            actionComplete = true;
        }
    }

    void UpdateHealth()
    {
        bossHealthBar.SetHealth(health);
    }

    void EnragedCheck()
    {
        if (!enraged)
        {
            if (health <= OGhealth / 10)
            {
                EnragedEnabled();
            }
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

    void EnragedEnabled()
    {
        FindObjectOfType<AudioManager>().Play("Enraged");
        enraged = true;
        health = OGhealth * 2;
        gameObject.GetComponent<BossGroundSlam>().enraged = true;
        gameObject.GetComponent<BossCharge>().enraged = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
}
