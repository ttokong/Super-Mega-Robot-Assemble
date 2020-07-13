using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        gameObject.GetComponentInParent<ShieldBash>().PullTrigger(c);
    }

}
