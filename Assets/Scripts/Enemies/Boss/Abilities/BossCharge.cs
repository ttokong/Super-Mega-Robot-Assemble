using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : MonoBehaviour
{
    public float chargeSpeedMultiplier;
    public float chargeUpDuration;
    private float chargeTime = 0;
    public Transform hitZone;
    public Transform bossEndTarget;
    private Vector3 endTarget;
    private bool chargeCheck = false;
    private BossBehaviour bb;
    private Vector3 dir;

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

    IEnumerator Charging()
    {
        chargeCheck = true;
        bb.attacking = true;
        endTarget = new Vector3(bossEndTarget.position.x, bossEndTarget.position.y, bossEndTarget.position.z);
        bb.agent.isStopped = false;
        bb.agent.SetDestination(endTarget);
        bb.agent.speed *= chargeSpeedMultiplier;
        bb.agent.acceleration *= chargeSpeedMultiplier;
        hitZone.localScale = new Vector3(1, 1, 0);
        yield return new WaitForSeconds(1f);
        bb.agent.speed /= chargeSpeedMultiplier;
        bb.agent.acceleration /= chargeSpeedMultiplier;
        bb.agent.isStopped = true;
        chargeTime = 0;
        bb.actionComplete = true;
        bb.attacking = false;
        chargeCheck = false;
    }

    //face player
    private void RotateToTarget()
    {
        dir = bb.target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
    }
}
