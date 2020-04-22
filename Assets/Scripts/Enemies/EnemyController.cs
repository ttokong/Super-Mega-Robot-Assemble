using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float stopRadius;

    public float aggroRadius;

    Transform target;

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        LocateTarget();
        InitGame();
    }

    void InitGame()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        agent.stoppingDistance = stopRadius;

        if (distance <= aggroRadius)
        {
            agent.SetDestination(target.position);
        }
    }


    void LocateTarget()
    {
        target = PlayerManager.instance.players[0].transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
