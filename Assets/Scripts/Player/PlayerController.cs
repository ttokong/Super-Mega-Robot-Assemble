using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerStats
{
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        OGhealth = health;
        CC = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        InputDecider();
        //Rotation();
    }


    void InputDecider()
    {
        float currentSpeed = new Vector2(movementInput.x, movementInput.y).sqrMagnitude;

        if(currentSpeed > allowRotation)
        {
            Rotation();
        }
        else
        {
            dir = Vector3.zero;
        }
    }

    void Rotation()
    {

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        dir = right * movementInput.x + forward * movementInput.y; 
        

        if (!aiming)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        }
    }




    void Movement()
    {
        gravity -= 9.8f * Time.deltaTime;
        gravity = gravity * gravityMultiplier;


        Vector3 moveDir = dir * (speed * Time.deltaTime);
        moveDir = new Vector3(moveDir.x, gravity, moveDir.z);
        CC.Move(moveDir);

        if(CC.isGrounded)
        {
            gravity = 0;
        }
    }
}
