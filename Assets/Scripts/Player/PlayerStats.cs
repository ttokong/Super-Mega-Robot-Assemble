using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    #region PhotonView

    [HideInInspector]
    public PhotonView PV;
    [HideInInspector]
    public AvatarSetup AS;

    #endregion

    public GameObject ghost;

    public float speed;

    public float health;

    public float ultiPercentage;
    public float ultiChargePerShot;

    public float allowRotation;

    public float gravityMultiplier;

    public GameObject bulletPrefab;

    public GameObject firePoint;

    public float firerate;

    public bool robotForm;

    [HideInInspector]
    public float gravity;

    [HideInInspector]
    public Vector3 dir;

    [HideInInspector]
    public bool shootTrig = false;

    [HideInInspector]
    public bool shooting = false;

    [HideInInspector]
    public Vector2 movementInput;

    [HideInInspector]
    public Vector2 aimInput;

    [HideInInspector]
    public float OGhealth;

    [HideInInspector]
    public CharacterController CC;

    [HideInInspector]
    public PlayerControls controls;

    [HideInInspector]
    public Camera cam;



    [PunRPC]
    public void RPC_PlayerTakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void DeathTrigger()
    {
        if (health <= 0)
        {
            PV.RPC("Dead", RpcTarget.All);
        }

        LevelManager.instance.HealthBars[PlayerInfo.instance.mySelectedCharacter].SetHealth(health);
        LevelManager.instance.UltimateBars[PlayerInfo.instance.mySelectedCharacter].SetUltimatePercentage(ultiPercentage);
    }

    [PunRPC]
    public void Dead()
    {
        Destroy(gameObject);
        // Instantiate(ghost, gameObject.position, Quaternion.identity);
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
