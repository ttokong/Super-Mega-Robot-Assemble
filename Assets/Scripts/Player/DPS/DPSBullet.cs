using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSBullet : MonoBehaviour
{
    List<GameObject> enemyInRange = new List<GameObject>();
    List<GameObject> dummyInRange = new List<GameObject>();

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
        // destroys itself if there is no target to move towards
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // calculates the distance between itself and target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // destroys itself if it has travelled the distance
        if (dir.magnitude <= distanceThisFrame)
        {
            enemyInRange.Clear();
            dummyInRange.Clear();
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
                DPSDamageEnemy(other.gameObject);

                Rigidbody rb = other.GetComponent<Rigidbody>();

                Vector3 dir = enemy.transform.position - transform.position;
                dir.y = 0;

                rb.AddForce(dir * knockbackStrength, ForceMode.Impulse);
            }

        }
        if (other.tag == "Dummy")
        {
            dummyInRange.Add(other.gameObject);

            foreach (GameObject dummy in dummyInRange)
            {
                if (other != null)
                {
                    DPSDamageDummy(other.gameObject);

                    Rigidbody rb = other.GetComponent<Rigidbody>();

                    Vector3 dir = dummy.transform.position - transform.position;
                    dir.y = 0;

                    rb.AddForce(dir * knockbackStrength, ForceMode.Impulse);
                }

            }
        }
    }

    void DPSDamageEnemy(GameObject enemy)
    {
        if (enemy = null)
            return;
        if (enemy.GetComponent<EnemyParameters>().bulletHit == false)
        {
            enemy.GetComponent<EnemyParameters>().bulletHit = true;
            enemy.GetComponent<MinionBehaviour>().stunned = true;
            // enemy.GetComponent<EnemyParameters>().bulletHit = true;
            enemy.GetComponent<EnemyParameters>().RPC_TakeDamage(damage);
        }
    }

    void DPSDamageDummy(GameObject dummy)
    {
        dummy.GetComponent<Dummy>().TakeDamage(damage);
    }

}
