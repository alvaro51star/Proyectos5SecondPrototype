using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ElectricitySwitch : InteractiveObject
{
    public delegate void SwitchActivation();
    public static event SwitchActivation OnSwitchActivation;

    private bool recentActivated = false;
    [SerializeField] private float timeToSwitchAgain = 0.5f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !recentActivated)
        {
            recentActivated = true;
            StartCoroutine(SetBoolFalse(timeToSwitchAgain));
            if(OnSwitchActivation != null)
                OnSwitchActivation();
        }
    }

    private IEnumerator SetBoolFalse(float time)
    {
        yield return new WaitForSeconds(time);
        recentActivated = false;
    }
}
