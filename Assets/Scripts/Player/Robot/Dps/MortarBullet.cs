using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBullet : MonoBehaviour
{
    public float explosionRadius;
    public GameObject impactEffect;

    [HideInInspector]
    public int dmg;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        GameObject effect = Instantiate(impactEffect, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
        Destroy(effect, 5f);
        DamageEnemies();
        Destroy(gameObject);
    }

    void DamageEnemies()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider col in cols)
        {
            if (col && col.tag == "Enemy")
            { // if object has the right tag...
                col.GetComponent<EnemyParameters>().RPC_TakeDamage(dmg);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere (transform.position, explosionRadius);
    }
}
