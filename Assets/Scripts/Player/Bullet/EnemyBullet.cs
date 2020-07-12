using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
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
        if (other.tag != "Enemy" && other.tag != "Bullet" && other.tag != "Ghost")
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PhotonView>().RPC("RPC_PlayerTakeDamage", RpcTarget.All, damage);

                DestroyBullet();
            }
            else
            {
                DestroyBullet();
            }
        }
    }

    [PunRPC]
    private void DestroyBullet()
    {
        Destroy(gameObject);

        GameObject effect = Instantiate(impactExplosion, transform.position, transform.rotation);
        Destroy(effect, 3f);
    }
}
