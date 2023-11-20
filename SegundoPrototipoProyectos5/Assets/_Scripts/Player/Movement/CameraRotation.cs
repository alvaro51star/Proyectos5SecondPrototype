using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField, Range(0,50)] private float sensitivityX, sensitivityY;
    [SerializeField, Range(0,90)] private float limitAngleX;

    private float yRotation, xRotation;
    [SerializeField] private Transform m_orientationPlayer;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //m_orientationPlayer = GameManager.instance.player.GetComponent<PlayerMovement>().orientation;
    }

    private void Update()
    {
        RotateCamera();
        RotatePlayer();        
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -limitAngleX, limitAngleX);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);        
    }

    private void RotatePlayer()
    {        
        m_orientationPlayer.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
