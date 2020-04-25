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
        if (other.tag != "Player")
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<PhotonView>().RPC("RPC_TakeDamage", RpcTarget.All, damage);
                Debug.Log("Damage");

                PV.RPC("DestroyBullet", RpcTarget.AllBuffered);
            }
            else
            {
                PV.RPC("DestroyBullet", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    private void DestroyBullet()
    {
        Destroy(gameObject);

        GameObject effect = PhotonNetwork.Instantiate(Path.Combine("Effects", "BulletExplosion"), transform.position, transform.rotation);
        Destroy(effect, 3f);
    }
}
