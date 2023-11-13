using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float openParachuteSpeed = -10f;
    [SerializeField] private GameObject parachute;
    [SerializeField] private float maxFallSpeed = -5f;

    private bool isOpened = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(rb.velocity.y);

        if (isOpened)
        {
            LimitVerticalSpeed();
        }

        if (rb.velocity.y <= openParachuteSpeed)
        {
            ActivateParachute();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            DeactivateParachute();
        }
    }

    private void ActivateParachute()
    {
        parachute.SetActive(true);
        isOpened = true;
    }

    private void LimitVerticalSpeed()
    {
        rb.velocity = new Vector3(0, maxFallSpeed, 0);
    }

    private void DeactivateParachute()
    {
        parachute.SetActive(false);
        isOpened = false;
    }
}
