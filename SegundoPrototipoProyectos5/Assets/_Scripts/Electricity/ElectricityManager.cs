using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    public bool active = false;

    public delegate void OnActiveChangeDelegate(bool newVal);
    public static event OnActiveChangeDelegate OnElectricityChange;

    private bool tempValue;

    private void Start()
    {
        tempValue = active;
        OnElectricityChange(active);
    }

    private void OnEnable()
    {
        ElectricitySwitch.OnSwitchActivation += SwitchElectricity;
    }

    private void OnDisable()
    {
        ElectricitySwitch.OnSwitchActivation -= SwitchElectricity;
    }

    private void SwitchElectricity()
    {
        active = !active;
    }

    private void Update()
    {
        if (tempValue != active && OnElectricityChange != null)
        {
            tempValue = active;
            OnElectricityChange(active);
        }
    }
}
