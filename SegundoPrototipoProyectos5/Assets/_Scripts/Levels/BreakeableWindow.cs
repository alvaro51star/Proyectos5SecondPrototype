using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakeableWindow : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
