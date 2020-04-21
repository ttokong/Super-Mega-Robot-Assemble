using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerStats
{

    void Awake()
    {
        cam = Camera.main;
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Shoot.performed += _ => Shoot();
        //controls.Gameplay.ShootHold.performed += a => ShootHold();
    }

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
    }


    void InputDecider()
    {

        float currentSpeed = new Vector2(movementInput.x, movementInput.y).sqrMagnitude;
        float aimSpeed = new Vector2(aimInput.x, aimInput.y).sqrMagnitude;

        if (currentSpeed > allowRotation && aimSpeed < allowRotation)
        {
            Rotation();
        }
        else if (currentSpeed > allowRotation && aimSpeed > allowRotation)
        {
            AimRotation();
        }
        else if (currentSpeed < allowRotation && aimSpeed > allowRotation)
        {
            AimRotation();
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

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);

    }


    void AimRotation()
    {

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        dir = right * movementInput.x + forward * movementInput.y;

        Vector3 aimDir = right * aimInput.x + forward * aimInput.y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDir), 0.15F);
    }



    void Movement()
    {
        gravity -= 9.8f * Time.deltaTime;
        gravity *= gravityMultiplier;


        Vector3 moveDir = dir * (speed * Time.deltaTime);
        moveDir = new Vector3(moveDir.x, gravity, moveDir.z);

        CC.Move(moveDir);

        if(CC.isGrounded)
        {
            gravity = 0;
        }
    }


    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }


    /*IEnumerator ShootHold()
    {
        if (!shootTrig)
        {
            shootTrig = true;
            yield return new WaitForSeconds(0.2f);
            Shoot();
            shootTrig = false;
        }

    }*/
}
