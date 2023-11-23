using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    public bool active = false;

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

    private void Update() {
        
    }
}
