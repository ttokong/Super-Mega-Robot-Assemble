using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSBullet : MonoBehaviour
{
    List<GameObject> enemyInRange = new List<GameObject>();

    public GameObject player;
    public Transform target;

    public float knockbackStrength;

    public int damage = 1;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Destroy(gameObject);
            GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 3f);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInRange.Add(other.gameObject);

            foreach (GameObject enemy in enemyInRange)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();

                Vector3 dir = enemy.transform.position - transform.position;
                dir.y = 0;

                rb.AddForce(dir * knockbackStrength, ForceMode.Impulse);

                DPSDamageEnemy(other.gameObject);
            }
        }
    }

    void DPSDamageEnemy(GameObject enemy)
    {
        if (enemy.GetComponent<MinionBehaviour>().bulletHit == false)
        {
            enemy.GetComponent<MinionBehaviour>().stunned = true;
            enemy.GetComponent<MinionBehaviour>().agent.isStopped = true;
            // enemy.GetComponent<EnemyParameters>().bulletHit = true;
            enemy.GetComponent<EnemyParameters>().RPC_TakeDamage(damage);
        }
    }

}
