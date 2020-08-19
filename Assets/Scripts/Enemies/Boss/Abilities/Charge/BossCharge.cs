using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : MonoBehaviour
{
    public bool enraged = false;

    //public float damage;
    int multipleDashCount;
    public float chargeSpeedMultiplier;
    public float chargeUpDuration;
    private float chargeTime = 0;
    public Transform hitZone;
    public Transform bossEndTarget;
    public Transform EnragedDashTarget;
    private bool enragedRotate = false;
    private Vector3 endTarget;
    private bool chargeCheck = false;
    private BossBehaviour bb;
    private Vector3 dir;

    public int damage;

    public bool charging = false;

    public GameObject ChargeEffect;

    public void Awake()
    {
        bb = gameObject.GetComponent<BossBehaviour>();
    }


    public void Charge()
    {
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

        if (enragedRotate)
        {
            EnragedRotateToTarget();
        }
    }

    IEnumerator Charging()
    {
        if (!enraged)
        {
            //finding charge target location
            chargeCheck = true;
            endTarget = new Vector3(bossEndTarget.position.x, bossEndTarget.position.y, bossEndTarget.position.z);

            //here the boss will move
            yield return new WaitForSeconds(.5f);
            FindObjectOfType<AudioManager>().Play("Charging");
            GameObject effect = Instantiate(ChargeEffect, transform.position, transform.rotation, gameObject.transform) as GameObject;
            yield return new WaitForSeconds(.2f);
            charging = true;

            Destroy(effect, 2f);

            hitZone.localScale = new Vector3(1, 1, 0);
            yield return new WaitForSeconds(1f);

            //finished charging
            charging = false;

            chargeTime = 0;
            bb.actionComplete = true;
            chargeCheck = false;
        }
        else if (enraged)
        {
            bb.enragedCharging = true;

            if (multipleDashCount == 0)
            {
                //finding charge target location
                chargeCheck = true;
                endTarget = new Vector3(bossEndTarget.position.x, bossEndTarget.position.y, bossEndTarget.position.z);

                //here the boss will move
                yield return new WaitForSeconds(.5f);
                FindObjectOfType<AudioManager>().Play("Charging");
                GameObject effect = Instantiate(ChargeEffect, transform.position, transform.rotation, gameObject.transform) as GameObject;
                yield return new WaitForSeconds(.2f);
                charging = true;

                Destroy(effect, 2f);

                hitZone.localScale = new Vector3(1, 1, 0);
                yield return new WaitForSeconds(1f);
                multipleDashCount++;

                //finished charging
                charging = false;

                chargeTime = 0;
                bb.actionComplete = true;
                chargeCheck = false;
                StartCoroutine(Charging());
            }
            if (multipleDashCount == 1)
            {
                enragedRotate = true;
                yield return new WaitForSeconds(1f);
                enragedRotate = false;

                //finding charge target location
                chargeCheck = true;
                endTarget = new Vector3(EnragedDashTarget.position.x, EnragedDashTarget.position.y, EnragedDashTarget.position.z);

                //here the boss will move
                yield return new WaitForSeconds(.5f);
                FindObjectOfType<AudioManager>().Play("Charging");
                GameObject effect = Instantiate(ChargeEffect, transform.position, transform.rotation, gameObject.transform) as GameObject;
                yield return new WaitForSeconds(.2f);
                charging = true;

                Destroy(effect, 2f);

                hitZone.localScale = new Vector3(1, 1, 0);
                yield return new WaitForSeconds(1f);
                multipleDashCount++;

                //finished charging
                charging = false;

                chargeTime = 0;
                bb.actionComplete = true;
                chargeCheck = false;
                StartCoroutine(Charging());
            }
            if (multipleDashCount == 2)
            {
                enragedRotate = true;
                yield return new WaitForSeconds(1f);
                enragedRotate = false;

                //finding charge target location
                chargeCheck = true;
                endTarget = new Vector3(EnragedDashTarget.position.x, EnragedDashTarget.position.y, EnragedDashTarget.position.z);

                //here the boss will move
                yield return new WaitForSeconds(.5f);
                FindObjectOfType<AudioManager>().Play("Charging");
                GameObject effect = Instantiate(ChargeEffect, transform.position, transform.rotation, gameObject.transform) as GameObject;
                yield return new WaitForSeconds(.2f);
                charging = true;

                Destroy(effect, 2f);

                hitZone.localScale = new Vector3(1, 1, 0);
                yield return new WaitForSeconds(1f);
                multipleDashCount = 0;
                //finished charging
                charging = false;
                chargeTime = 0;
                bb.actionComplete = true;
                chargeCheck = false;

                bb.enragedCharging = false;
            }
        } 
    }

    //face player
    private void RotateToTarget()
    {
        dir = bb.target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
    }

    private void EnragedRotateToTarget()
    {
        dir = bb.target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2F);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && charging == true)
        {
            other.GetComponent<PlayerStats>().RPC_PlayerTakeDamage(damage);
        }
        if (other.tag == "Robot" && charging == true)
        {
            LevelManager.instance.transformBar.currentCharge -= 1;
            LevelManager.instance.transformBar.SetCharge();
        }
    }
}
