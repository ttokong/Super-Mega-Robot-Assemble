using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    #region PhotonView

    public PhotonView PV;
    [HideInInspector]
    public AvatarSetup AS;

    #endregion

    public GameObject ghost;

    public float speed;

    public int health;

    public int Iframe;
    private bool invincible;

    public int ultiPercentage;
    public int ultiChargePerShot;

    public float allowRotation;

    public float gravityMultiplier;

    public GameObject bulletPrefab;

    public GameObject firePoint;

    public float firerate;

    public bool robotForm;

    public MultipleTargetCamera multipleTargetCamera;

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
    public int OGhealth;

    [HideInInspector]
    public CharacterController CC;

    [HideInInspector]
    public PlayerControls controls;

    [HideInInspector]
    public Camera cam;



    [PunRPC]
    public void RPC_PlayerTakeDamage(int dmg)
    {
        if (!invincible)
        {
            health -= dmg;

            foreach (Health hp in LevelManager.instance.HealthBars)
            {
                if (hp.playerID == PlayerInfo.instance.mySelectedCharacter)
                {
                    hp.TakeDamage();
                    hp.SetHealth(health);
                }
            }

            StartCoroutine(IframeCalc());
        }
        else
            return;
    }

    IEnumerator IframeCalc()
    {
        invincible = true;
        yield return new WaitForSeconds(Iframe);
        invincible = false;

    }

    [PunRPC]
    public void RPC_PlayerHeal(int heal)
    {
        health += heal;
        if (health > OGhealth)
        {
            health = OGhealth;
        }

        foreach (Health hp in LevelManager.instance.HealthBars)
        {
            if (hp.playerID == PlayerInfo.instance.mySelectedCharacter)
            {
                hp.SetHealth(health);
            }
        }
    }

    [PunRPC]
    public void RPC_SetUltCharge(int UltCharge)
    {
        Mathf.Clamp(ultiPercentage += UltCharge, 0, 4);


        foreach (UltimateCharge ub in LevelManager.instance.UltimateBars)
        {
            if (ub.playerID == PlayerInfo.instance.mySelectedCharacter)
            {
                ub.SetUltimatePercentage(ultiPercentage);
            }
        }

        LevelManager.instance.transformBar.AddCharge(ultiChargePerShot + 2);
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
