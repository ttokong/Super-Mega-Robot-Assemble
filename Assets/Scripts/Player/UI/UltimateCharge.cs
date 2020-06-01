using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateCharge : MonoBehaviour
{
    public Slider UltimateSlider;

    private void Awake()
    {
        UltimateSlider.maxValue = 100f;        
    }

    public void SetUltimatePercentage(float ultiPercentage)
    {
        UltimateSlider.value = ultiPercentage;
    }
}
