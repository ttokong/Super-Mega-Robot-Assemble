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
        if (other.tag != "Enemy" && other.tag != "Bullet" && 
            other.tag != "Ghost" && other.tag != "Hitbox")
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PhotonView>().RPC("RPC_PlayerTakeDamage", RpcTarget.All, damage);
            }
            if (other.tag == "Shield")
            {
                other.GetComponent<Shield>().timesHit++;
            }
            if (other.tag == "Robot")
            {
                LevelManager.instance.transformBar.currentCharge -= 1;
                LevelManager.instance.transformBar.SetCharge();
            }
            DestroyBullet();
        }
    }

    [PunRPC]
    public void DestroyBullet()
    {
        Destroy(gameObject);

        GameObject effect = Instantiate(impactExplosion, transform.position, transform.rotation);
        Destroy(effect, 3f);
    }
}
