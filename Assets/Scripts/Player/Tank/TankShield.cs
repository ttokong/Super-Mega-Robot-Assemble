using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShield : MonoBehaviour
{
    public GameObject shieldHolder;
    public int shieldHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHealth <= 0)
        {
            shieldHolder.SetActive(false);
            shieldHealth = 5;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            other.GetComponent<EnemyBullet>().DestroyBullet();
            shieldHealth -= 1;
        }
    }

}
