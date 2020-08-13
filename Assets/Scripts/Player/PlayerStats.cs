using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector]
    public PlayerConfiguration playerconfig;

    public int PlayerIndex;

    public GameObject ghost;

    public float speed;

    public int health;

    public int Iframe;
    private bool invincible;

    public int ultiCharge;
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
    public Camera cam;

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerconfig = pc;
    }

    public void RPC_PlayerTakeDamage(int dmg)
    {
        if (!invincible)
        {
            health -= dmg;

            foreach (Health hp in LevelManager.instance.HealthBars)
            {
                if (hp.playerID == playerconfig.SelectedCharacter)
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


    public void RPC_PlayerHeal(int heal)
    {
        health += heal;
        if (health > OGhealth)
        {
            health = OGhealth;
        }

        foreach (Health hp in LevelManager.instance.HealthBars)
        {
            if (hp.playerID == playerconfig.SelectedCharacter)
            {
                hp.SetHealth(health);
            }
        }
    }

    public void RPC_SetUltCharge(int UltCharge)
    {
        Mathf.Clamp(ultiCharge += UltCharge, 0, 4);

        if (ultiCharge >= 4)
        {
            ultiCharge = 4;
        }


        foreach (UltimateCharge ub in LevelManager.instance.UltimateBars)
        {
            if (ub.playerID == playerconfig.SelectedCharacter)
            {
                ub.SetUltimatePercentage(ultiCharge);
            }
        }

        LevelManager.instance.transformBar.AddCharge(ultiChargePerShot + 2);
    }

    public void DeathTrigger()
    {
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
        // create a prefab as a gameobject at this transform and setting the new gameobject as a reference
        GameObject deadplayer = Instantiate(ghost, gameObject.transform.position, Quaternion.identity) as GameObject;
        deadplayer.GetComponent<GhostScript>().player = gameObject;
    }

}
