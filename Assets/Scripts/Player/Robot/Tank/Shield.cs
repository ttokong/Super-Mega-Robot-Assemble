using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject rippleVFX;

    private Material mat;

    public Color phase1;
    public Color phase2;
    public Color phase3;

    private ShieldBash sb;

    public int MultiplierThreshold;

    public int timesHit;

    private void Start()
    {
        sb = GetComponent<ShieldBash>();
        mat = GetComponentInChildren<ParticleSystemRenderer>().material;
        Debug.Log(mat.name);
    }
    private void Update()
    {

        if (timesHit >= MultiplierThreshold)
        {
            
            if (timesHit < (MultiplierThreshold * 2))     //Damage * 2
            {
                UpdateColour(2);
                sb.damageMultiplier = 2;
            }    
            else if (timesHit >= (MultiplierThreshold * 2))       //Damage * 3
            {
                timesHit = (MultiplierThreshold * 2);     //wont exceed max
                UpdateColour(3);
                sb.damageMultiplier = 3;
            }

        }
        else if (timesHit < MultiplierThreshold)
        {
            UpdateColour(1);
            sb.damageMultiplier = 1;
        }
    }

    private Color c;


    void UpdateColour(int Phase)
    {
        if (Phase == 1)
        {
            c = mat.GetVector("Color_4667603B");
            c = Color.Lerp(c, phase1 * 5, 1);
            mat.SetVector("Color_4667603B", c); 
        }
        else if (Phase == 2)
        {
            c = Color.Lerp(c, phase2 * 5, 1);
            mat.SetVector("Color_4667603B", c);
        }
        else if (Phase == 3)
        {
            c = Color.Lerp(c, phase3 * 5, 1);
            mat.SetVector("Color_4667603B", c);
        }
    }
}
