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
        cam = Camera.main;
        multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();
        timer = Random.Range(0, 4);
        agent = GetComponent<NavMeshAgent>();
        PV = GetComponent<PhotonView>();
        OGhealth = health;
        multipleTargetCamera.targets.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();

        RngDecider();
    }

    void RngDecider()
    {
        if (actionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= actionTimer)
            {
                PV.RPC("LocateRandomTarget", RpcTarget.All);
                actionID = Random.Range(0, 17);
                timer = Random.Range(0, 4);         // randomly reduces wait time between each action by 0 to 3 seconds
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


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
}
