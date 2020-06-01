using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformBar: MonoBehaviour
{
    public Image Fill;
    public float maxCharge = 100f;
    public float currentCharge;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseCharge", 0f, 5.25f);
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
