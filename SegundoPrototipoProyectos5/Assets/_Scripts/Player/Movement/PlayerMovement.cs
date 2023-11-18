using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    [Header("HAY QUE PONER AL SUELO LA LAYER GROUND PARA QUE FUNCIONE EL MOVIMIENTO")]

    public Transform cameraPosition;
    public Transform orientation;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float groundDrag;

    [Header ("Ground check")]
    [SerializeField] private GameObject groundCheckObject;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField, Range (0,1)] private float airResistance;
   
    
    private Rigidbody m_rb;
    private AudioSource m_audioSource;

    private float m_horizontalInput;
    private float m_verticalInput;
    private Vector3 m_moveDirection;

    private GroundCheck m_groundCheck;
    private bool m_grounded;


    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.freezeRotation = true;
        m_groundCheck = groundCheckObject.GetComponent<GroundCheck>();

        m_audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        m_grounded = m_groundCheck.isGrounded;

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
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
        m_verticalInput = Input.GetAxisRaw("Vertical");       

        if (Input.GetButtonDown("Jump") && m_grounded)
            Jump();
    }

    private void MovePlayer()
    {
        m_moveDirection = orientation.forward * m_verticalInput + orientation.right * m_horizontalInput;

        if (m_grounded)
            m_rb.AddForce(m_moveDirection.normalized * (speed * 10f), ForceMode.Force); //sin el 10 va muy lento
        else if(!m_grounded)
            m_rb.AddForce(m_moveDirection.normalized * (speed * 10f * airResistance), ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 actualSpeed = new Vector3(m_rb.velocity.x, 0, m_rb.velocity.z);

        if(actualSpeed.magnitude > speed)
        {
            Vector3 limitedSpeed = actualSpeed.normalized * speed;
            m_rb.velocity = new Vector3(limitedSpeed.x, m_rb.velocity.y, limitedSpeed.z);
        }
    }
    private void Jump()
    {
        m_rb.velocity = new Vector3(m_rb.velocity.x, 0, m_rb.velocity.z); //si no reseteas la v.y y vuelves a saltar salta muy alto
        m_rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);        
        //SoundManager.instance.ReproduceSound(AudioClipsNames.Jump, m_audioSource);
    }
    private void HandleDrag()
    {
        if (m_grounded)
            m_rb.drag = groundDrag;
        else
            m_rb.drag = 0;
    }    
}
