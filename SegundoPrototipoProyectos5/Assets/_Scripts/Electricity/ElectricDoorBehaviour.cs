using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricDoorBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private bool active = false;
    [SerializeField] private WaterConductiveZone waterConductiveZone;
    private void OnEnable()
    {
        ElectricityManager.OnElectricityChange += SetActive;
    }

    private void OnDisable()
    {
        ElectricityManager.OnElectricityChange -= SetActive;
    }    

    private void Update()
    {
        UnlockDoor(waterConductiveZone.waterReached);
    }

    private void SetActive(bool electricityStatus)
    {
        active = electricityStatus;
    }

    private void UnlockDoor(bool hasWaterReachTheArea)
    {
        if (active && hasWaterReachTheArea)
        {
            door.SetActive(false);            
        }
        else
        {
            door.SetActive(true);
            
        }
    }
}
