using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject rippleVFX;

    private Material mat;

    private void OnCollisionEnter(Collision co)
    {
        Debug.Log(co.transform.name);

        //if (co.gameObject.tag == "Bullet")
        //{
        //    Debug.Log("Bullet");
        //    GameObject ripples = Instantiate(rippleVFX, transform) as GameObject;
        //    ParticleSystemRenderer psr = ripples.transform.GetChild(0).GetComponent<ParticleSystemRenderer>();
        //    mat = psr.material;
        //    //mat.SetVector("HitOffSet", co.contacts[0].point);

        //    Destroy(ripples, 2);
        //}
    }
}
