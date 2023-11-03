using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [Header("Water settings")]
    [SerializeField] private float maxWater = 5f;
    [SerializeField] private float thrustForce = 0.5f;
    [SerializeField] ParticleSystem waterParticleSystem;
    private Rigidbody rb;

    private float currentWater;
    [Header("Player variables")]
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Transform playerCamera;


    private bool canMoveWithWater = false;

    private void Start()
    {
        currentWater = maxWater;
        playerCamera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && currentWater > 0)
        {
            currentWater -= Time.deltaTime;
            waterParticleSystem.Play();

            if (!groundCheck.isGrounded){
                canMoveWithWater = true;
            }
            else{
                canMoveWithWater = false;
            }
        }
        else
        {
            canMoveWithWater = false;
            waterParticleSystem.Stop();
        }

        /*if (groundCheck.isGrounded)
        {
            currentWater = maxWater; //!Esto puede cambiar a que haya otras fuentes de agua.
        }*/

        Debug.Log(currentWater);
    }

    private void FixedUpdate()
    {
        if (canMoveWithWater)
        {
            rb.AddForce(-playerCamera.forward * thrustForce, ForceMode.Impulse);
        }
    }

    /// <summary>Recarga el agua</summary>
    public void RechargeWater()
    {
        currentWater = maxWater;
    }
}
