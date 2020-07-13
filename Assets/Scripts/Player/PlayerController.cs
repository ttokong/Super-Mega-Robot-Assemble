using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController : PlayerStats
{

    void Awake()
    {
        cam = Camera.main;
        controls = new PlayerControls();
        multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.ShootHold.performed += context => RapidFire(context);
        controls.Gameplay.SuperMegaRobotAssemble.performed += context => RobotAssemble(context);
        controls.Gameplay.Ultimate.performed += context => Ultimate(context);
        controls.Gameplay.Pause.performed += context => Pause(context);
        InitSequence();
    }
    

    void InitSequence()
    {
        OGhealth = health;
        LevelManager.instance.HealthBars[0].SetIcon(PlayerInfo.instance.mySelectedCharacter);
        Debug.Log(PlayerInfo.instance.mySelectedCharacter);

        PV = gameObject.GetComponent<PhotonView>();
        CC = gameObject.GetComponent<CharacterController>();
        
        // adds the gameobject this script is attached to as a target in the multiple target camera script
        multipleTargetCamera.targets.Add(gameObject.transform);
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
            else if (robotForm)
            {
                //gameObject.SetActive(false);
                multipleTargetCamera.targets.Remove(gameObject.transform);
                gameObject.SetActive(false);
                Destroy(gameObject, 5f);
                LevelManager.instance.robot.SetActive(true);
            }
        }

    }

    // check for which input is being used by player and calls for appropriate functions
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

    // rotation of player character
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

    // aim rotation of player
    void AimRotation()
    {
        Joystick js = Joystick.current;
        Mouse mouse = Mouse.current;

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        dir = right * movementInput.x + forward * movementInput.y;

        if (js == null)
        {
            Ray ray = cam.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 350f))
            {
                Vector3 mouseDir = hit.point - transform.position;
                Quaternion qDir = Quaternion.LookRotation(new Vector3(mouseDir.x, 0, mouseDir.z));

                transform.rotation = Quaternion.Slerp(transform.rotation, qDir, 0.15F);

            }
        }
        else
        {
            Vector3 aimDir = right * aimInput.x + forward * aimInput.y;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDir), 0.15F);
        }

    }


    // movement
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

    // when shooting projectiles
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

    // transformation into robot
    void RobotAssemble(InputAction.CallbackContext context)
    {
        if(PV.IsMine)
        {
            float value = context.ReadValue<float>();

            if (robotForm == false && LevelManager.instance.transformBar.currentCharge >= LevelManager.instance.transformBar.maxCharge)
            {
                if (value >= 0.9)
                {
                    PV.RPC("RPC_SuperRobotMegaAssemble", RpcTarget.All);
                }
            }

        }
    }

    // player's personal ultimate
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

    void Pause(InputAction.CallbackContext context)
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
    private void RPC_SuperRobotMegaAssemble()
    {
        PlayerController[] player = FindObjectsOfType<PlayerController>();
        foreach (PlayerController p in player)
        {
            p.robotForm = true;
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
