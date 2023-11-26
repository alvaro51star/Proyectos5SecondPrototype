using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakeableWindow : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
