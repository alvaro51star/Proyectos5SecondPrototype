using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class WaterUpdating : MonoBehaviour
{
    [SerializeField] private Image slider;

    private void OnEnable()
    {
        WaterGun.OnWaterChange += ChangeSlider;
    }

    private void OnDisable()
    {
        WaterGun.OnWaterChange -= ChangeSlider;
    }

    private void ChangeSlider(float currentWater, float maxWater)
    {
        slider.fillAmount = currentWater / maxWater;
    }
}
