using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class BulletScript : MonoBehaviour
{

    private float bulletSpeed = 100;

    public float bulletSpeedMultiplier;

    public float damage;

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
                other.GetComponent<PhotonView>().RPC("RPC_TakeDamage", RpcTarget.All, damage);

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
