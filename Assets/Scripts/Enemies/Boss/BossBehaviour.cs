using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class BossBehaviour : EnemyParameters
{

    private int actionID;

    private float timer;
    public float actionTimer;

    public bool actionComplete = true;


    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        timer = actionTimer;
        agent = GetComponent<NavMeshAgent>();
        PV = GetComponent<PhotonView>();
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
        if (actionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= actionTimer)
            {
                actionID = Random.Range(0, 17);
                timer = Random.Range(0, 4);         // randomly reduces wait time between each action by 0 to 3 seconds
                actionComplete = false;
            }
        }
        else if (!actionComplete)
        {
            if (actionID >= 0 && actionID <= 5)    //33.33% chance to wander
            {
                Wander();
            }
            else if (actionID >= 6 && actionID <= 11)    //33.33% chance to ground slam
            {
                gameObject.GetComponent<BossGroundSlam>().Slam();
            }
            else if (actionID >= 12 && actionID <= 17)    //33.33% chance to charge
            {
                gameObject.GetComponent<BossCharge>().Charge();
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


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
}
