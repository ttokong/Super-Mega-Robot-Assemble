using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSSkill : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject bulletPrefab;
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DPS()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<DPSBullet>().target = targets[i].transform;
            bullet.GetComponent<DPSBullet>().player = this.gameObject;
        }
    }

}
