using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float speed;

    public float health;
    public float ultiPercentage;
    

    [HideInInspector]
    public float OGhealth;

    [HideInInspector]
    public CharacterController CC;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
}
