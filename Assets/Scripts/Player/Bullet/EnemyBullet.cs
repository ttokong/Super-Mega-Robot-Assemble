using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (other.tag != "Enemy" && other.tag != "Bullet")
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PhotonView>().RPC("RPC_PlayerTakeDamage", RpcTarget.All, damage);

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
