using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class RobotController : PlayerStats
{
    public GameObject[] robotParts;

    void Awake()
    {
        cam = Camera.main;
        multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
    }

    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        OGhealth = health;
        //PV = GetComponent<PhotonView>();
        CC = gameObject.GetComponent<CharacterController>();

        multipleTargetCamera.targets.Add(gameObject.transform);
    }

    void Update()
    {
        //if (PV.IsMine)
        //{
            if (PhotonRoom.room.myNumberInRoom == 2)
            {
                Movement();
            }


            InputDecider();                             // dont touch this thanks
        //}

    }


    void InputDecider()
    {
        float currentSpeed = new Vector2(movementInput.x, movementInput.y).sqrMagnitude;

        if (currentSpeed > allowRotation)                   //if u exceed a certain speed u will rotate basically
        {
            Rotation();
        }
        else
        {
            dir = Vector3.zero;                             //if not moving then dont rotate
        }
    }


    void Rotation()                 //this part makes u rotate to face the direction of movement
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

        /*
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
        }*/

        if (PhotonRoom.room.myNumberInRoom == 1)
        {
            robotParts[0].transform.rotation = Quaternion.Slerp(robotParts[0].transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        }
        else if (PhotonRoom.room.myNumberInRoom == 2)
        {
            robotParts[1].transform.rotation = Quaternion.Slerp(robotParts[1].transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        }

        
    }

    void Movement()
    {
        gravity -= 9.8f * Time.deltaTime;
        gravity *= gravityMultiplier;


        Vector3 moveDir = dir * (speed * Time.deltaTime);
        moveDir = new Vector3(moveDir.x, gravity, moveDir.z);

        CC.Move(moveDir);

        if (CC.isGrounded)
        {
            gravity = 0;
        }
    }
}
