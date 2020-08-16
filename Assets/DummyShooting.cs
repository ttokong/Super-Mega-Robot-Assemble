using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyShooting : MonoBehaviour
{
    private bool shootTrig = false;
    public float firerate;
    public GameObject bullets;
    public GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTrig == false)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        shootTrig = true;
        yield return new WaitForSeconds(1 / firerate);
        RPC_Fire();
        shootTrig = false;
    }

    private void RPC_Fire()
    {
        FindObjectOfType<AudioManager>().Play("LaserGun");
        Instantiate(bullets, firePoint.transform.position, transform.rotation);
    }
}
