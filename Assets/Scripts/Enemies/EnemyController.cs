using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float stopRadius;

    GameObject target;

    NavMeshAgent agent;

    private EnemyParameters e;


    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        agent = GetComponent<NavMeshAgent>();
        e = GetComponent<EnemyParameters>();

        agent.stoppingDistance = stopRadius;

        LocateRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!e.Wandering)
        {
            if (e.followTarget)
            {
                if(agent.isStopped == true)
                {
                    agent.isStopped = false;
                }

                agent.SetDestination(target.transform.position);
            }
            else
            {
                if (agent.isStopped == false)
                {
                    agent.isStopped = true;
                }

            }
        }


    }

    public void LocateRandomTarget()
    {
        // find gameobject with tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //targetting the selected random player
        target = players[Random.Range(0, PhotonRoom.room.playersInRoom - 1)];
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
