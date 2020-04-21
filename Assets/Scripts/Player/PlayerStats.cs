using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    public float speed;

    public float health;
    public float ultiPercentage;

   
    PlayerControls controls;

    public bool aiming;

    public float allowRotation;

    public float gravityMultiplier;

    [HideInInspector]
    public float gravity;

    [HideInInspector]
    public Vector3 dir;

    [HideInInspector]
    public Vector2 movementInput;

    [HideInInspector]
    public float OGhealth;

    [HideInInspector]
    public CharacterController CC;

    [HideInInspector]
    public Camera cam;

    public void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        cam = Camera.main;
    }

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
