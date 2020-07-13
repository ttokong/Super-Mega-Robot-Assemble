using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShieldBash : MonoBehaviour
{
    public GameObject hitBox;
    public int damage;
    public int damageMultiplier = 1;
    public Transform hitZone;

    public float chargeUpDuration;
    private float chargeTime = 0;

    public float cooldown;
    private float cd;

    private bool charging;


    private void Start()
    {
        cd = cooldown;
    }
    private void Update()
    {
        cd += Time.deltaTime;

        if (charging)
        {
            chargeTime += Time.deltaTime;
            hitZone.localScale = new Vector3(1, 1, 0 + (((chargeTime * (damageMultiplier * .30f + .80f))/1.2f) / chargeUpDuration));
            Bash();
        }
    }

    public void Bash()
    {
        if (cd >= cooldown)
        {
            if (chargeTime <= chargeUpDuration)
            {
                charging = true;
            }
            else if (chargeTime > chargeUpDuration)
            {
                hitBox.SetActive(true);
                GetComponent<PhotonView>().RPC("RPC_ShieldBash", RpcTarget.All);
                StartCoroutine(BashCo());
                chargeTime = 0;
                cd = 0;
                charging = false;
            }
        }
        else
            return;
    }

    public void PullTrigger(Collider c)
    {
        if (c.tag == "Enemy")
        {
            c.GetComponent<PhotonView>().RPC("RPC_TakeDamage", RpcTarget.All, damage * damageMultiplier);
        }
    }
    IEnumerator BashCo()
    {
        yield return new WaitForSeconds(.1f);
        hitZone.localScale = new Vector3(1, 1, 0);
        hitBox.SetActive(false);
    }

    [PunRPC]
    void RPC_ShieldBash()
    {
        GetComponent<Shield>().timesHit = 0;
    }
}
