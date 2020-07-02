using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RobotController : MonoBehaviour
{
    public GameObject[] robotParts;


    public float health;
    private float OGhealth;


    private PhotonView PV;
    private CharacterController CC;
    private PlayerControls controls;
    private Camera cam;
    public float allowRotation;
    private Vector2 movementInput;
    private Vector3 dir;

    public float speed;
    private float gravity;
    public float gravityMultiplier;

    void Awake()
    {
        cam = Camera.main;
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();        
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

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        dir = right * movementInput.x + forward * movementInput.y;
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


    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }
}
