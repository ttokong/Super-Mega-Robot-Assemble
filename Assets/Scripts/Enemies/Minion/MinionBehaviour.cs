using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        OGhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        DeathTrigger();
        //ChangeLocation();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMax);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetRadiusMin);
    }
    /*
    void GenerateDirection()
    {
        Vector3 dir = Vector3.zero;
        while(dir == Vector3.zero)
        {
            dir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        }

        dir = dir.normalized;

        //Assuming the small circle radius is 5 and the large radius is 10.
        float Magnitude = Random.Range(targetRadiusMin, targetRadiusMax);

        //Create you spawn Vector
        Vector3 targetLocation = dir * Magnitude;
        //Height Vector, ten high (change to what you want).
        Height_Vector = Vector3(0, 10, 0);
        //Use Spawn Vector in relation to character position to get spawn position.
        //and adjust with the Height_Vector.
        Spawn_Position = Character.transform.position + Spawn_Vector + Height_Vector;
    }
    void ChangeLocation()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, targetRadiusMax, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }*/
}
