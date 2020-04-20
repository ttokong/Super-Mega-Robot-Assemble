using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerStats
{

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void InitGame()
    {
        OGhealth = health;
        CC = gameObject.GetComponent<CharacterController>();
    }



    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        CC.Move(move * speed * Time.deltaTime);
    }
}
