using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofSecure : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }
}
