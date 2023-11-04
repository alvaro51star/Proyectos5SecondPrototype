using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRecharge : MonoBehaviour
{
    private bool empty = false;
    [SerializeField] private GameObject water;
    private void OnCollisionEnter(Collision other)
    {
        if (!empty && !other.gameObject.GetComponent<WaterGun>().IsWaterGunFull())
        {
            other.gameObject.GetComponent<WaterGun>().RechargeWater();
            empty = true;
            water.SetActive(false);
        }
    }
}