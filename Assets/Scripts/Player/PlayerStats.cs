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

    public Health healthBar;

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

    [PunRPC]
    public void RPC_PlayerHeal(float heal)
    {
        health += heal;
    }

    public void DeathTrigger()
    {
        if (health <= 0)
        {
            PV.RPC("Dead", RpcTarget.All);
        }
    }

    [PunRPC]
    public void Dead()
    {
        gameObject.SetActive(false);
        // create a prefab as a gameobject at this transform and setting the new gameobject as a reference
        GameObject deadplayer = Instantiate(ghost, gameObject.transform.position, Quaternion.identity) as GameObject;
        deadplayer.GetComponent<GhostScript>().player = gameObject;
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
