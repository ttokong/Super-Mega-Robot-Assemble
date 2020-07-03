using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankCC : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            RPC_stunMinions(other.gameObject);
        }
    }

    [PunRPC]
    void RPC_stunMinions(GameObject Enemy)
    {
        Enemy.GetComponent<MinionBehaviour>().stunned = true;
    }
}
