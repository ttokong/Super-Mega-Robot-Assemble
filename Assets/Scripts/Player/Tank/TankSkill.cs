using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSkill : MonoBehaviour
{
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TankShield()
    {
        shield.SetActive(true);
    }

}
