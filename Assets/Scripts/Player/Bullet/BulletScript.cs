using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class BulletScript : MonoBehaviour
{
    private PhotonView PV;

    private float bulletSpeed = 100;

    public float bulletSpeedMultiplier;

    public float damage;

    public GameObject impactExplosion;

    private Rigidbody bullet;

    void Start()
    {
        PV = GetComponent<PhotonView>();

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

                PV.RPC("DestroyBullet", RpcTarget.All);
            }
            else
            {
                PV.RPC("DestroyBullet", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void DestroyBullet()
    {
        Destroy(PV.gameObject);

        GameObject effect = Instantiate(impactExplosion, transform.position, transform.rotation);
        Destroy(effect, 3f);
    }
}
