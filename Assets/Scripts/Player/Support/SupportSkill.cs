using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportSkill : MonoBehaviour
{
    public GameObject VacuumRadius;
    public GameObject VacuumPoint;
    private float VacuumDuration = 4f;
    public float knockbackStrength;

    public List<GameObject> amountofEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        VacuumRadius.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PullTrigger(Collider other)
    {
        amountofEnemies.Add(other.gameObject);

        for (int i = 0; i < amountofEnemies.Count; i++)
        {
            foreach (GameObject enemies in amountofEnemies)
            {
                Rigidbody rb = enemies.GetComponent<Rigidbody>();

                Vector3 dir = enemies.transform.position - transform.position;
                dir.y = 0;

                rb.AddForce(dir * knockbackStrength, ForceMode.Impulse);

                // Vacuum(enemies.gameObject);
            }
        }
    }

    /* public void Vacuum(GameObject enemy)
    {
        enemy.GetComponent<MinionBehaviour>().stunned = true;
        // enemy.GetComponent<MinionBehaviour>().agent.isStopped = true;
        // enemy.GetComponent<EnemyParameters>().bulletHit = true;
    } */

    public void BufferTime()
    { 
        StartCoroutine(StartBuffer());
    }

    IEnumerator StartBuffer()
    {
        VacuumRadius.SetActive(true);
        yield return new WaitForSeconds(.2f);
        VacuumRadius.SetActive(false);
        amountofEnemies.Clear();
    }
}
