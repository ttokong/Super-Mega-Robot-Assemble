using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    public float speed;

    public float health;

    public float ultiPercentage;


    public float allowRotation;

    public float gravityMultiplier;

    public GameObject bulletPrefab;

    public GameObject firePoint;

    public float firerate;

    [HideInInspector]
    public float gravity;

    [HideInInspector]
    public Vector3 dir;

    [HideInInspector]
    public bool shootTrig = false;

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

    public void TakeDamage(float dmg)
    {
        health -= dmg;
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
