using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossCharge : MonoBehaviour
{
    //public float damage;
    public float chargeSpeedMultiplier;
    public float chargeUpDuration;
    private float chargeTime = 0;
    public Transform hitZone;
    public Transform bossEndTarget;
    private Vector3 endTarget;
    private bool chargeCheck = false;
    private BossBehaviour bb;
    private Vector3 dir;

    public bool charging = false;

    public GameObject ChargeEffect;

    public void Awake()
    {
        bb = gameObject.GetComponent<BossBehaviour>();
    }


    public void Charge()
    {
        Debug.Log("Charge");
        if (chargeTime <= chargeUpDuration)
        {
            bb.agent.isStopped = true;
            RotateToTarget();   
            chargeTime += Time.deltaTime;
            hitZone.localScale = new Vector3(1, 1, 0 + chargeTime/chargeUpDuration);
            transform.position -= dir.normalized * Time.deltaTime;
        }
        else if (chargeTime > chargeUpDuration)
        {
            if (!chargeCheck)
            {
                StartCoroutine(Charging());
            }
        }

    }

    private void Update()
    {
        if (charging)
        {
            transform.position = Vector3.Lerp(transform.position, endTarget, chargeSpeedMultiplier);
        }
    }

    IEnumerator Charging()
    {
        //finding charge target location
        chargeCheck = true;
        endTarget = new Vector3(bossEndTarget.position.x, bossEndTarget.position.y, bossEndTarget.position.z);

        //here the boss will move
        yield return new WaitForSeconds(.5f);
        GameObject effect = Instantiate(ChargeEffect, transform.position, transform.rotation, gameObject.transform) as GameObject;
        yield return new WaitForSeconds(.2f);
        charging = true;
        //bb.agent.isStopped = false;
        //bb.agent.SetDestination(endTarget);
        Destroy(effect, 2f);
        //bb.agent.speed *= chargeSpeedMultiplier;
        //bb.agent.acceleration *= chargeSpeedMultiplier;
        hitZone.localScale = new Vector3(1, 1, 0);
        yield return new WaitForSeconds(1f);

        //finished charging
        charging = false;
        //bb.agent.speed /= chargeSpeedMultiplier;
        //bb.agent.acceleration /= chargeSpeedMultiplier;
        //bb.agent.isStopped = true;
        chargeTime = 0;
        bb.actionComplete = true;
        chargeCheck = false;
    }

    //face player
    private void RotateToTarget()
    {
        dir = bb.target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && charging == true)
        {
            other.GetComponent<PhotonView>().RPC("RPC_PlayerTakeDamage", RpcTarget.All, damage);
        }
    }*/
}
