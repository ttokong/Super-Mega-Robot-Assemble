using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class MinionBehaviour : EnemyParameters
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        PV = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        OGhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();
        ChangeLocation();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }

    void ChangeLocation()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Wandering = true;
            if (agent.isStopped)
            {
                agent.isStopped = false;
            }

            Vector3 newPos = RandomNavSphere(transform.position, targetRadiusMax, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;


        NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, layermask);

        return navHit.position;
    }
}
