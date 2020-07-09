using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Childtrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<HealthPack>().PullTrigger(other);
        }
    }

}
