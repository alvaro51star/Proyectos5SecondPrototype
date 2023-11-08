using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerUpdating : MonoBehaviour
{
    [SerializeField] private Image slider;
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        GameManager.OnTimeChange += ChangeSlider;
        GameManager.OnTimeChange += ChangeText;
    }

    private void OnDisable()
    {
        GameManager.OnTimeChange -= ChangeSlider;
        GameManager.OnTimeChange -= ChangeText;
    }

    private void ChangeSlider(float time)
    {
        slider.fillAmount = time / GameManager.instance.maxTimeLevel;
    }

    private void ChangeText(float time)
    {
        text.text = $"{(time / 60) - 1:00} : {time % 60:00}";
    }

}
