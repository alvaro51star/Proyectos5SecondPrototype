using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRecharge : InteractiveObject
{
    private bool empty = false;
    [SerializeField] private GameObject water;

    public delegate void OnWaterRechargeDelegate();
    public static event OnWaterRechargeDelegate OnWaterRecharge;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!empty && !other.GetComponent<WaterGun>().IsWaterGunFull())
                {
                    other.gameObject.GetComponent<WaterGun>().RechargeWater();
                    empty = true;
                    water.SetActive(false);
                    other.GetComponent<WaterGun>().InvokeOnWaterChange();
                }
            }
        }
    }
}
