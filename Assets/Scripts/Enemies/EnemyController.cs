using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float stopRadius;

    NavMeshAgent agent;

    private EnemyParameters e;


    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        // references to navmeshagent
        agent = GetComponent<NavMeshAgent>();
        e = GetComponent<EnemyParameters>();

        // sets the distance for enemies to stop from the player
        agent.stoppingDistance = stopRadius;
    }

    // Update is called once per frame
    void Update()
    {
        //  FollowTarget();
    }

    void FollowTarget()
    {
        if (e.followTarget)
        {
            agent.SetDestination(e.target.position);
        }
    }

    public void LocateRandomTarget()
    {
        // find gameobject with tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //targetting the selected random player
        e.target = players[Random.Range(0, PhotonRoom.room.playersInRoom - 1)].transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
