using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    int OGhealth = 60;
    public int health;

    public float inCombatCD = 5f;
    public bool gettingHit = false;

    public DummyHealthBar dummyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = OGhealth;
        dummyHealthBar.SetMaxHealth(OGhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gettingHit)
        {
            health = OGhealth;
        }
        else
        {
            inCombatCD -= Time.deltaTime;
        }

        if (inCombatCD <= 0f)
        {
            gettingHit = false;
            inCombatCD = 5f;
        }

        if (health <= 5)
        {
            health = 5;
        }

        UpdateHealth();
    }

    void UpdateHealth()
    {
        dummyHealthBar.SetHealth(health);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        gettingHit = true;
        inCombatCD = 5f;
    }
}
