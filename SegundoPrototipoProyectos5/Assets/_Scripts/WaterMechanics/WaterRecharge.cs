using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRecharge : MonoBehaviour
{
    private bool empty = false;
    [SerializeField] private GameObject water;

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
                }
            }

        }
    }
}
