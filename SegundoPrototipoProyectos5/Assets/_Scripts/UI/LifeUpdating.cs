using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUpdating : MonoBehaviour
{    
    [SerializeField] private Image slider;

    private void OnEnable()
    {
        LifeManager.OnLifeChange += ChangeLifeSlider;
    }

    private void OnDisable()
    {
        LifeManager.OnLifeChange -= ChangeLifeSlider;
    }

    private void ChangeLifeSlider(float life, float maxLife)
    {
        slider.fillAmount = life / maxLife;
    }
}
