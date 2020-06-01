using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using System.IO;

public class PlayerController : PlayerStats
{


    void Awake()
    {
        cam = Camera.main;
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.ShootHold.performed += context => RapidFire(context);
        controls.Gameplay.SuperMegaRobotAssemble.performed += context => RobotAssemble(context);
        controls.Gameplay.Ultimate.performed += context => Ultimate(context);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        OGhealth = health;
        LevelManager.instance.HealthBars[PlayerInfo.instance.mySelectedCharacter].SetMaxHealth(health);
        PV = GetComponentInParent<PhotonView>();
        CC = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            if(!robotForm)
            {
                Movement();
                InputDecider();

                DeathTrigger();

                StartCoroutine(Shoot());
            }
        }

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

    void RapidFire(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        shooting = value >= 0.9f; //if value is more than 0.9, shooting = true, else false.
    }

    IEnumerator Shoot()
    {
        if(shooting)
        {
            if (!shootTrig)
            {
                shootTrig = true;
                PV.RPC("RPC_Fire", RpcTarget.All);
                yield return new WaitForSeconds(1/firerate);
                shootTrig = false;
            }
        }

    }

    void RobotAssemble(InputAction.CallbackContext context)
    {
        if(PV.IsMine)
        {
            float value = context.ReadValue<float>();

            if (robotForm == false)
            {
                if (value >= 0.9)
                {
                    gameObject.SetActive(false);
                    LevelManager.instance.robot.SetActive(true);
                    GetComponent<AvatarSetup>().PV.RPC("RPC_AddRobotPart", RpcTarget.AllViaServer);
                    robotForm = true;
                }
            }

        }
    }

    void Ultimate(InputAction.CallbackContext context)
    {
        if (PV.IsMine)
        {
            float value = context.ReadValue<float>();


            if (value >= 0.9) //if button is pressed
            {
               
            }
        }
    }


    [PunRPC]
    private void RPC_Fire()
    {
        Debug.Log("Fire");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation) as GameObject;
        bullet.GetComponent<BulletScript>().player = gameObject;
    }
}
