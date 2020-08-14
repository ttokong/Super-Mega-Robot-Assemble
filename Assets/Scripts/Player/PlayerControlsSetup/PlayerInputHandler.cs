using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerConfiguration playerConfig;
    private PlayerController pc;
    private RobotController rc;

    private PlayerControls controls;

    public void Awake()
    {
        pc = GetComponent<PlayerController>();
        controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        playerConfig.Input.onActionTriggered += Input_OnActionTriggered;
    }

    public void InitializeRobot(PlayerConfiguration config)
    {
        playerConfig = config;
        playerConfig.Input.onActionTriggered += Input_OnActionTriggered;
        rc = GetComponent<RobotController>();
    }

    private void Input_OnActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Gameplay.Move.name)
        {
            OnMove(obj);
        }
        else if (obj.action.name == controls.Gameplay.Aim.name)
        {
            Aim(obj);
        }
        else if (obj.action.name == controls.Gameplay.ShootHold.name)
        {
            OnShoot(obj);
        }
        else if (obj.action.name == controls.Gameplay.SuperMegaRobotAssemble.name)
        {
            BANKAI(obj);
        }
        else if (obj.action.name == controls.Gameplay.Ultimate.name)
        {
            Ulti(obj);
        }
        else if (obj.action.name == controls.Gameplay.Pause.name)
        {
            OnPause(obj);
        }
    }

    public void OnMove(CallbackContext ctx)
    {
        if (pc != null && !pc.robotForm)
        {
            pc.GetMovementVector(ctx.ReadValue<Vector2>());
        }
        else
        {
            if (rc != null)
            {
                rc.GetMovementVector(ctx.ReadValue<Vector2>());
            }
        }
    }

    public void Aim(CallbackContext ctx)
    {
        if (pc != null && !pc.robotForm)
        {
            pc.GetRotationVector(ctx.ReadValue<Vector2>());
        }
        else
        {
            if (rc != null)
            {
                rc.GetRotationVector(ctx.ReadValue<Vector2>());
            }
        }
    }

    public void OnShoot(CallbackContext context)
    {

        if (pc != null && !pc.robotForm)
        {
            pc.RapidFire(context.ReadValue<float>());
        }
        else
        {
            if (rc != null)
            {
                rc.RapidFire(context.ReadValue<float>());
            }
        }
    }

    public void BANKAI(CallbackContext context)
    {
        if (pc != null && !pc.robotForm)
        {
            pc.RobotAssemble(context.ReadValue<float>());
        }
    }

    public void Ulti(CallbackContext context)
    {
        if (pc != null && !pc.robotForm)
        {
            pc.Ultimate(context.ReadValue<float>());
        }
        else
        {
            if (rc != null)
            {
                rc.Ultimate(context.ReadValue<float>());
            }
        }
    }

    public void OnPause(CallbackContext context)
    {
        if (pc != null && !pc.robotForm)
        {
            pc.Pause(context.ReadValue<float>());
        }
        else
        {
            if (rc != null)
            {
                pc.Pause(context.ReadValue<float>());
            }
        }
    }
}
