using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLightBehaviour : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Material enabledMaterial, disabledMaterial;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        ElectricityManager.OnElectricityChange += ChangeLightState;
    }

    private void OnDisable()
    {
        ElectricityManager.OnElectricityChange -= ChangeLightState;
    }

    private void ChangeLightState(bool electrityStatus)
    {
        if (electrityStatus)
        {
            meshRenderer.material = enabledMaterial;
        }
        else
        {
            meshRenderer.material = disabledMaterial;
        }
    }


}
