using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 100;

    public GameObject impactExplosion;

    public float bulletSpeedMultiplier;

    public float damage;

    private Rigidbody bullet;

    void Start()
    {
        bulletSpeed *= bulletSpeedMultiplier;

        bullet = gameObject.GetComponent<Rigidbody>();
        bullet.velocity = transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyParameters>().TakeDamage(damage);

                DestoryBullet();
            }
            else
            {
                DestoryBullet();
            }
        }
    }

    private void DestoryBullet()
    {
        Destroy(gameObject);

        GameObject effect = (GameObject)Instantiate(impactExplosion, transform.position, transform.rotation);
        Destroy(effect, 3f);
    }
}
