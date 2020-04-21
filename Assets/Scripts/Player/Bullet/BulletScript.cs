using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 100;
    public float bulletSpeedMultiplier;

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
            Destroy(gameObject);
        }

    }
}
