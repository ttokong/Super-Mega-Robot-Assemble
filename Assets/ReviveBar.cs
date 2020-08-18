using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTime(float timer)
    {
        slider.maxValue = timer;
        slider.value = timer;
    }

    // whenever this is called, script will find slider and adjust the value
    public void SetTime(float timer)
    {
        slider.value = timer;
    }

}
