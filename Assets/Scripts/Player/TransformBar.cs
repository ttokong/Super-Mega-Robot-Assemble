using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformBar: MonoBehaviour
{
    public Image Fill;
    public float maxCharge = 100f;
    public float currentCharge;
    public Color originalColour;
    public Color NewColour;

    private float t = 0;
    private bool colourSwitch;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseCharge", 0f, 5.25f);
    }


    private void Update()
    {
        if(currentCharge >= maxCharge)
        {
            if (t <= 1)
            {
                t += Time.deltaTime;
            }
            else if (t > 1)
            {
                t = 0;

                if (colourSwitch)
                {
                    colourSwitch = false;
                }
                else if (!colourSwitch)
                {
                    colourSwitch = true;
                }
            }


            if (colourSwitch)
            {
                Fill.color = Color.Lerp(NewColour, originalColour, t);
            }
            else if (!colourSwitch)
            {
                Fill.color = Color.Lerp(originalColour, NewColour, t);
            }

        }
        else
        {
            Fill.color = originalColour;
            t = 0;
            colourSwitch = false;
        }
    }

    void IncreaseCharge()
    {
        currentCharge++;
        SetCharge();

    }

    public void AddCharge(float teamUltCharge)
    {
        currentCharge += teamUltCharge;
        SetCharge();
    }

    void SetCharge ()
    {
        Fill.fillAmount = currentCharge / maxCharge;
    }
}
