using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class RobotController : MonoBehaviour
{

    public float allowRotation;
    public GameObject[] robotParts;
    public int health;
    public float gravityMultiplier;
    public float speed;
    public GameObject crosshair;

    private PhotonView PV;
    private float gravity;
    private Camera cam;
    private MultipleTargetCamera multipleTargetCamera;
    private PlayerControls controls;
    private Vector2 movementInput;
    private Vector2 aimInput;
    private CharacterController CC;
    private int OGhealth;
    private Vector3 dir;

    private Rigidbody rb;
    public float dashSpeed;
    public float dashDuration;

    void Awake()
    {
        cam = Camera.main;
        multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();

        rb = GetComponent<Rigidbody>();

        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Pause.performed += context => Pause(context);
        controls.Gameplay.Ultimate.performed += context => Ultimate(context);
    }


    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        OGhealth = health;
        PV = GetComponent<PhotonView>();
        CC = GetComponent<CharacterController>();

        multipleTargetCamera.targets.Add(gameObject.transform);
    }

    void Update()
    {
        if (PV.IsMine)
        {
            if (LevelManager.instance.transformBar.currentCharge > 0)
            {
                LevelManager.instance.transformBar.currentCharge -= Time.deltaTime;
                LevelManager.instance.transformBar.SetCharge();
            }
            else
            {
                gameObject.SetActive(false);
                GameObject.Find("GameSetupController").GetComponent<GameSetupController>().CreatePlayer();
                gameObject.transform.position = new Vector3(0, 0, 0);
            }

            if (PlayerInfo.instance.mySelectedCharacter == 2)
            {
                Movement();
            }

            InputDecider();                             // dont touch this thanks
        }

    }


    void InputDecider()
    {
        float currentSpeed = new Vector2(movementInput.x, movementInput.y).sqrMagnitude;
        float aimSpeed = new Vector2(aimInput.x, aimInput.y).sqrMagnitude;

        if (PlayerInfo.instance.mySelectedCharacter == 2)
        {
            if (currentSpeed > allowRotation)                   //if u exceed a certain speed u will rotate basically
            {
                Rotation();
            }
            else
            {
                dir = Vector3.zero;                             //if not moving then dont rotate
            }
        }
        else
        {
            if (aimSpeed > allowRotation)
            {
                AimRotation();
            }
            else if (aimSpeed > allowRotation)
            {
                AimRotation();
            }
            else
            {
                dir = Vector3.zero;                             //if not moving then dont rotate
            }
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

        robotParts[2].transform.rotation = Quaternion.Slerp(robotParts[2].transform.rotation, Quaternion.LookRotation(dir), 0.15F);

    }

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


        if (PlayerInfo.instance.mySelectedCharacter == 0)                //tank
        {
            if (js == null) 
            {
                Ray ray = cam.ScreenPointToRay(mouse.position.ReadValue());
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 350f))
                {
                    Vector3 mouseDir = hit.point - transform.position;
                    Quaternion qDir = Quaternion.LookRotation(new Vector3(mouseDir.x, 0, mouseDir.z));

                    robotParts[1].transform.rotation = Quaternion.Slerp(robotParts[1].transform.rotation, qDir, 0.15F);

                }
            }
            else
            {
                Vector3 aimDir = right * aimInput.x + forward * aimInput.y;

                robotParts[1].transform.rotation = Quaternion.Slerp(robotParts[1].transform.rotation, Quaternion.LookRotation(aimDir), 0.15F);
            }
        }
        else if (PlayerInfo.instance.mySelectedCharacter == 1)           //dps
        {
            if (js == null)
            {
                Ray ray = cam.ScreenPointToRay(mouse.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 350f))
                {
                    Vector3 mouseDir = hit.point - transform.position;
                    Quaternion qDir = Quaternion.LookRotation(new Vector3(mouseDir.x, 0, mouseDir.z));

                    robotParts[0].transform.rotation = Quaternion.Slerp(robotParts[0].transform.rotation, qDir, 0.15F);

                    crosshair.transform.position = hit.point;
                }
            }
            else
            {
                Vector3 aimDir = right * aimInput.x + forward * aimInput.y;

                robotParts[0].transform.rotation = Quaternion.Slerp(robotParts[0].transform.rotation, Quaternion.LookRotation(aimDir), 0.15F);
            }
        }
        else if (PlayerInfo.instance.mySelectedCharacter == 2)           //support
        {
            robotParts[2].transform.rotation = Quaternion.Slerp(robotParts[2].transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        }


    }



    void Movement()
    {
        gravity -= 9.8f * Time.deltaTime;
        gravity *= gravityMultiplier;


        Vector3 moveDir = dir * (speed * Time.deltaTime);
        Debug.Log(dir);
        moveDir = new Vector3(moveDir.x, gravity, moveDir.z);

        CC.Move(moveDir);

        if (CC.isGrounded)
        {
            gravity = 0;
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

                if (PlayerInfo.instance.mySelectedCharacter == 0)
                {
                    GetComponentInChildren<ShieldBash>().Bash();
                }
                else if (PlayerInfo.instance.mySelectedCharacter == 1)
                {

                }
                else if (PlayerInfo.instance.mySelectedCharacter == 2)
                {
                    Debug.Log("dkawh");
                    StartCoroutine(RobotDash());
                }
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

    IEnumerator RobotDash()
    {
        rb.AddForce(Vector3.forward * dashSpeed);

        yield return new WaitForSeconds(dashDuration);
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
