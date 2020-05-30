using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformBar: MonoBehaviour
{
    public Image Fill;
    public float maxCharge = 100f;
    public float currentCharge =0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("increaseCharge", 0f, 5.25f);
    }
    
    void increaseCharge()
    {
        currentCharge += 1f;
        float calculateCharge = currentCharge / maxCharge;
        SetCharge(calculateCharge);

    }

    void SetCharge (float myCharge)
    {
        Fill.fillAmount = myCharge;
    }
}
