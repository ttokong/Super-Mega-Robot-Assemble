using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RobotController : MonoBehaviour
{
    public GameObject Legs;
    public GameObject Arms_L;
    public GameObject Arms_R;
    public GameObject Torso;

    public int playerID;


    private PlayerControls controls;
    private Camera cam;
    public float allowRotation;
    private Vector2 movementInput;
    private Vector3 dir;


    void Awake()
    {
        cam = Camera.main;
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();        
    }

    void Update()
    {
        InputDecider();                             // dont touch this thanks
    }


    void InputDecider()
    {
        if (playerID == 1 && playerID == 2)
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

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
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
