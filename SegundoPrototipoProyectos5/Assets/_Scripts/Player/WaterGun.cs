using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [SerializeField] private float maxWater = 5f;
    [SerializeField] private float thrustForce = 0.5f;
    private Rigidbody rb;

    private float currentWater;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Transform playerCamera;

    private void Start()
    {
        currentWater = maxWater;
        playerCamera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && currentWater > 0 && !groundCheck.isGrounded)
        {
            currentWater -= Time.deltaTime;
            //Activar sistemas de particulas
            rb.AddForce(-playerCamera.forward * thrustForce, ForceMode.Impulse);
        }

        if (groundCheck.isGrounded)
        {
            currentWater = maxWater; //!Esto puede cambiar a que haya otras fuentes de agua.
        }

        Debug.Log(currentWater);
    }


}
