using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public float allowRotation;
    public GameObject[] robotParts;
    public int health;
    public float gravityMultiplier;
    public float speed;
    public GameObject crosshair;

    private float gravity;
    private Camera cam;
    private MultipleTargetCamera multipleTargetCamera;
    private PlayerControls controls;
    private Vector2 movementInput;
    private Vector2 aimInput;
    private Vector2 DPSaimInput;
    private CharacterController CC;
    private int OGhealth;
    private Vector3 dir;
    private Vector3 SPdir;
    private Vector3 DPdir;

    public GameObject headrotate;
    public float dpsRange;
    public float crosshairSpeed;

    public bool IsDashing = false;
    public bool IsAddingCharge = false;
    public float dashSpeed;
    public int dashCharges;
    public float dashChargesCD;
    public float dashCD;
    public bool dashCDing = false;
    public Transform OGtarget;
    public Vector3 currentTarget;

    /* public Rigidbody rb;
    public float dashSpeed;
    public float dashDuration; */

    void Awake()
    {
        cam = Camera.main;
        multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();

        //rb = GetComponent<Rigidbody>();

        controls = new PlayerControls();
    }


    void Start()
    {
        InitSequence();
    }

    void InitSequence()
    {
        OGhealth = health;
        CC = GetComponent<CharacterController>();

        multipleTargetCamera.targets.Add(gameObject.transform);
    }

    void Update()
    {
        if (LevelManager.instance.transformBar.currentCharge > 0)
        {
            LevelManager.instance.transformBar.currentCharge -= Time.deltaTime;
            LevelManager.instance.transformBar.SetCharge();
        }
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("RobotDead");
            GameObject.Find("GameSetupController").GetComponent<GameSetupController>().CreatePlayer();
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }

        // (playerconfig.SelectedCharacter == 2)
        //{
            Movement();
        //}

        InputDecider();                             // dont touch this thanks

        // when dash button is pressed, check whether there are still dash charges and whether it is still CDing or not
        if (IsDashing)
        {
            if (dashCharges > 0 && dashCDing == false)
            {
                FindObjectOfType<AudioManager>().Play("RobotSupport");
                StartCoroutine(Dash());
                dashCharges--;
                //IsDashing = false;
                currentTarget = new Vector3(OGtarget.position.x, OGtarget.position.y, OGtarget.position.z);
                transform.position = Vector3.Lerp(transform.position, currentTarget, dashSpeed);

            }
            else
            {
                IsDashing = false;
            }
        }

        // adds a charge of dash after a CD if it goes below 3
        if (dashCharges < 3 && IsAddingCharge == false)
        {
            StartCoroutine(AddDashCharges());
            IsAddingCharge = true;
        }
    }


    void InputDecider()
    {
        float currentSpeed = new Vector2(movementInput.x, movementInput.y).sqrMagnitude;
        float aimSpeed = new Vector2(aimInput.x, aimInput.y).sqrMagnitude;
        float DPSaimSpeed = new Vector2(DPSaimInput.x, DPSaimInput.y).sqrMagnitude;

        //if (playerconfig.SelectedCharacter == 2)
        {
            if (currentSpeed > allowRotation)                   //if u exceed a certain speed u will rotate basically
            {
                Rotation();
            }
            else
            {
                SPdir = Vector3.zero;                             //if not moving then dont rotate
            }
        }
        //else
        //{
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

        if (DPSaimSpeed > allowRotation)
        {
            AimRotation();
        }
        else if (DPSaimSpeed > allowRotation)
        {
            AimRotation();
        }
        else
        {
            DPdir = Vector3.zero;                             //if not moving then dont rotate
        }
        //}    
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

        SPdir = right * movementInput.x + forward * movementInput.y;

        robotParts[2].transform.rotation = Quaternion.Slerp(robotParts[2].transform.rotation, Quaternion.LookRotation(SPdir), 0.15F);

    }


    public void GetRotationVector(Vector2 rotationv, int c)
    {
        if (c == 0)
        {
            aimInput = rotationv;
        }
        else if (c == 1)
        {
            DPSaimInput = rotationv;
        }
        else { return; }

    }

    void AimRotation()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        SPdir = right * movementInput.x + forward * movementInput.y;


        //if (playerconfig.SelectedCharacter == 0)                //tank
        //{
            Vector3 aimDir = right * aimInput.x + forward * aimInput.y;

            robotParts[1].transform.rotation = Quaternion.Slerp(robotParts[1].transform.rotation, Quaternion.LookRotation(aimDir), 0.15F);
        //}
        //else if (playerconfig.SelectedCharacter == 1)           //dps
        //{
            /*
                Ray ray = cam.ScreenPointToRay(mouse.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 350f))
                {
                    Vector3 mouseDir = hit.point - transform.position;
                    Quaternion qDir = Quaternion.LookRotation(new Vector3(mouseDir.x, 0, mouseDir.z));

                    GetComponent<LaserScript>().ShootLaserFromTargetPosition
                            (GetComponent<LaserScript>().firepoint.transform.position, hit.point - GetComponent<LaserScript>().firepoint.transform.position, 
                            GetComponent<LaserScript>().laserMaxLength);

                    robotParts[0].transform.rotation = Quaternion.Slerp(robotParts[0].transform.rotation, qDir, 0.15F);

                    crosshair.transform.position = hit.point;
                } */

            Vector3 DPSaimDir = right * DPSaimInput.x + forward * DPSaimInput.y;


        headrotate.transform.rotation = Quaternion.Slerp(headrotate.transform.rotation, Quaternion.LookRotation(DPSaimDir), 0.15F);

        robotParts[0].transform.rotation = Quaternion.Slerp(robotParts[0].transform.rotation, Quaternion.LookRotation(-(robotParts[0].transform.position - crosshair.transform.position)), 0.15F);

        GetComponent<LaserScript>().ShootLaserFromTargetPosition
                        (GetComponent<LaserScript>().firepoint.transform.position, crosshair.transform.position - GetComponent<LaserScript>().firepoint.transform.position,
                        GetComponent<LaserScript>().laserMaxLength);

        crosshair.transform.position += headrotate.transform.forward * Time.deltaTime * crosshairSpeed;

        //clamp
        Vector3 v = crosshair.transform.position - transform.position;
        v = Vector3.ClampMagnitude(v, dpsRange);
        crosshair.transform.position = transform.position + v;

        //}
        //else if (playerconfig.SelectedCharacter == 2)           //support
        //{
            robotParts[2].transform.rotation = Quaternion.Slerp(robotParts[2].transform.rotation, Quaternion.LookRotation(SPdir), 0.15F);
        //}


    }

    public void RapidFire(float value, int c)
    {
        if (c == 1)
        {


            if (value >= 0.9) //if button is pressed
            {
                GetComponent<LaserScript>().ShootBeam();
            }
        }
        else { return; }
    }


    public void GetMovementVector(Vector2 movementv, int c)
    {
        if (c == 2)
        {
            movementInput = movementv;
        }
        else { return; }
    }


    void Movement()
    {
        gravity -= 9.8f * Time.deltaTime;
        gravity *= gravityMultiplier;


        Vector3 moveDir = SPdir * (speed * Time.deltaTime);
        moveDir = new Vector3(moveDir.x, gravity, moveDir.z);

        CC.Move(moveDir);

        if (CC.isGrounded)
        {
            gravity = 0;
        }
    }

    // player's personal ultimate
    public void Ultimate(float value, int c)
    {

        if (value >= 0.9) //if button is pressed
        {

            if (c == 0)
            {
                GetComponentInChildren<ShieldBash>().Bash();
            }
            else if (c == 1)
            {
                GetComponent<Mortar>().Shoot();
            }
            else if (c == 2)
            {
                IsDashing = true;
                // StartCoroutine(RobotDash());
            }
        }
    }


    public void Pause(float value)
    {
        if (value >= 0.9) //if button is pressed
        {
            if (PauseMenu.gameIsPaused)
            {
                PauseMenu.gameIsPaused = false;
            }
            else if (!PauseMenu.gameIsPaused)
            {
                PauseMenu.gameIsPaused = true;
            }
        }
    }

    // makes sure players are unable to spam dashes
    IEnumerator Dash()
    {
        dashCDing = true;
        yield return new WaitForSeconds(dashCD);
        IsDashing = false;
        dashCDing = false;
    }

    // adds a charge of dash after a CD if it goes below 3
    IEnumerator AddDashCharges()
    {
        yield return new WaitForSeconds(dashChargesCD);
        dashCharges++;
        IsAddingCharge = false;
    }

    /* IEnumerator RobotDash()
    {
        Debug.Log("dkawh");
        rb.AddForce(Vector3.forward * dashSpeed);

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = Vector3.zero;
    } */


    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }
}
