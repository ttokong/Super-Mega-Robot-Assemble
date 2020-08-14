using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            other.GetComponent<EnemyParameters>().RPC_TakeDamage(damage);
        }
        if (other.tag == "Robot")
        {
            LevelManager.instance.transformBar.currentCharge -= 1;
            LevelManager.instance.transformBar.SetCharge();
        }
    }
}
