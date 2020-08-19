using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSSkill : MonoBehaviour
{
    CharacterController cc;
    public GameObject[] targets;

    public GameObject bulletPrefab;
    public Transform firepoint;

    bool isCasting = false;
    Quaternion rotationY;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isCasting)
        {
            rotationY = gameObject.transform.rotation;
        }
        else if (isCasting)
        {
            gameObject.transform.rotation = rotationY;
        }
    }

    public void DPS()
    {
        // does this once for every bullet there is from dps skill (3 currently)
        for (int i = 0; i < targets.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<DPSBullet>().target = targets[i].transform;
            bullet.GetComponent<DPSBullet>().player = this.gameObject;
        }

        StartCoroutine(StartCasting());
    }

    IEnumerator StartCasting()
    {
        isCasting = true;

        yield return new WaitForSeconds(0.1f);

        isCasting = false;
    }

}
