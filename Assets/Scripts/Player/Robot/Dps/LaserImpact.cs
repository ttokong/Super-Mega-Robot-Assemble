using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaserImpact : MonoBehaviour
{
    public int damage;

    private CapsuleCollider CC;

    private void Start()
    {
        CC = GetComponent<CapsuleCollider>();
        StartCoroutine(DisableCollider());
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(.2f);
        CC.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<PhotonView>().RPC("RPC_TakeDamage", RpcTarget.All, damage);
        }
        if (other.tag == "Robot")
        {
            LevelManager.instance.transformBar.currentCharge -= 1;
            LevelManager.instance.transformBar.SetCharge();
        }
    }
}
