using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
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
                other.GetComponent<PhotonView>().RPC("RPC_TakeDamage", RpcTarget.All, damage);

                player.GetComponent<PhotonView>().RPC("RPC_SetUltCharge", RpcTarget.All, player.GetComponent<PlayerStats>().ultiChargePerShot);
                //LevelManager.instance.transformBar.AddCharge(player.GetComponent<PlayerStats>().ultiChargePerShot / 3);

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
