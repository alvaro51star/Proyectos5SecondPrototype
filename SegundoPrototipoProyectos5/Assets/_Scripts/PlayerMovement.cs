using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("HAY QUE PONER AL SUELO LA LAYER GROUND PARA QUE FUNCIONE EL MOVIMIENTO")]

    public Transform cameraPosition;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float groundDrag;

    [Header ("Ground check")]
    [SerializeField] private float playerHeight;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float airResistance;

    
    private Rigidbody rb;
    private Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private LayerMask groundMask;
    private bool grounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        orientation = GetComponent<Transform>();
        rb.freezeRotation = true;
        groundMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask); //la mitad de la altura del player + un poco más NO FUNCIONA BIEN

        GetInput();
        SpeedControl();
        HandleDrag();
    }    

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && grounded)
            Jump();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if(grounded)
            rb.AddForce(moveDirection.normalized * (speed * 10f), ForceMode.Force); //sin el 10 va muy lento
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * (speed * 10f * airResistance), ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 actualSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(actualSpeed.magnitude > speed)
        {
            Vector3 limitedSpeed = actualSpeed.normalized * speed;
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z);
        }
    }
    private void Jump()
    {
        Debug.Log("deberia estar saltando");
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); //si no reseteas la v.y y vuelves a saltar salta muy alto
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);               
    }
    private void HandleDrag()
    {
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
}
