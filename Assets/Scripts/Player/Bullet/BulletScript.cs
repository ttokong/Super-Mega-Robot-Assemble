using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BulletScript : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;

    private float bulletSpeed = 100;

    public float bulletSpeedMultiplier;

    public int damage;

    public GameObject impactExplosion;

    private Rigidbody bullet;

    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody>();

        bulletSpeed *= bulletSpeedMultiplier;
    }

    private void Update()
    {
        bullet.velocity = transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Bullet")
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyParameters>().RPC_TakeDamage(damage);

                player.GetComponent<PlayerStats>().RPC_SetUltCharge(player.GetComponent<PlayerStats>().ultiChargePerShot);

                DestroyBullet();
            }
            else if (other.tag == "Dummy")
            {
                other.GetComponent<Dummy>().TakeDamage(damage);

                player.GetComponent<PlayerStats>().RPC_SetUltCharge(player.GetComponent<PlayerStats>().ultiChargePerShot);

                DestroyBullet();
            }
            else
            {
                DestroyBullet();
            }
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);

        GameObject effect = Instantiate(impactExplosion, transform.position, transform.rotation);
        Destroy(effect, 3f);
    }
}
