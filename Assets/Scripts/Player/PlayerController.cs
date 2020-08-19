using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System.Linq;

public class PlayerController : PlayerStats
{

    void Awake()
    {
        cam = Camera.main;
        multipleTargetCamera = cam.GetComponentInParent<MultipleTargetCamera>();
        InitSequence();
    }

    private void Start()
    {
        LevelManager.instance.HealthBars[0].SetIcon(playerconfig.SelectedCharacter);
    }

    public int GetPlayerIndex()
    {
        return PlayerIndex;
    }


    void InitSequence()
    {
        OGhealth = health;

        CC = gameObject.GetComponent<CharacterController>();
        
        // adds the gameobject this script is attached to as a target in the multiple target camera script
        multipleTargetCamera.targets.Add(gameObject.transform);
    }


    // Update is called once per frame
    void Update()
    {
        if(!robotForm && gameObject.activeSelf == true)
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
            LevelManager.instance.robot.GetComponent<RobotController>().InitializeRobot(playerconfig);
            LevelManager.instance.robot.GetComponent<PlayerInputHandler>().InitializeRobot(playerconfig);
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

    public void GetRotationVector(Vector2 rotationv)
    {
        aimInput = rotationv;
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

    public void GetMovementVector(Vector2 movementv)
    {
        movementInput = movementv;
    }

    public void RapidFire(float value)
    {
        shooting = value >= 0.6f; //if value is more than 0.9, shooting = true, else false.
    }

    // when shooting projectiles
    IEnumerator Shoot()
    {
        if(shooting)
        {
            if (!shootTrig)
            {
                shootTrig = true;
                RPC_Fire();
                yield return new WaitForSeconds(1/firerate);
                shootTrig = false;
            }
        }

    }

    // transformation into robot
    public void RobotAssemble(float value)
    {

        if (robotForm == false && LevelManager.instance.transformBar.currentCharge >= LevelManager.instance.transformBar.maxCharge)
        {
            if (value >= 0.9)
            {
                PlayerManager.instance.Ult(playerconfig.PlayerIndex, this);
            }
        }

    }

    // player's personal ultimate
    public void Ultimate(float value)
    {


        if (value >= 0.9) //if button is pressed
        {
            if (ultiCharge == 4)
            {
                switch (playerconfig.SelectedCharacter)
                {
                    // tank
                    case 0:
                        this.GetComponent<TankSkill>().TankShield();
                        break;

                    // dps
                    case 1:
                        this.GetComponent<DPSSkill>().DPS();
                        break;

                    // support
                    case 2:
                        this.GetComponent<SupportSkill>().BufferTime();
                        break;
                }

                ultiCharge = 0;
                foreach (UltimateCharge ub in LevelManager.instance.UltimateBars)
                {
                    if (ub.playerID == playerconfig.SelectedCharacter)
                    {
                        ub.SetUltimatePercentage(ultiCharge);
                    }
                }
            }
        }
    }

    public void Pause(float value)
    {
        if (value >= 0.9) //if button is pressed
        {
            Debug.Log("yep");
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

    public void RPC_SuperRobotMegaAssemble()
    {
        PlayerController[] player = FindObjectsOfType<PlayerController>();
        foreach (PlayerController p in player)
        {
            p.robotForm = true;
        }
    }

    private void RPC_Fire()
    {
        Debug.Log("Fire");
        FindObjectOfType<AudioManager>().Play("LaserGun");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation) as GameObject;
        bullet.GetComponent<BulletScript>().player = gameObject;
    }
}
