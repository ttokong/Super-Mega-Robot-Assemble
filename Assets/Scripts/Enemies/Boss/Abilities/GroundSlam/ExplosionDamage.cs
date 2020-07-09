using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ExplosionDamage : MonoBehaviour
{
    public float damage;
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
        if (other.tag == "Player")
        {
            other.GetComponent<PhotonView>().RPC("RPC_PlayerTakeDamage", RpcTarget.All, damage);
        }
    }
}
