using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField, Range(0,50)] private float sensitivityX, sensitivityY;

    private float yRotation, XRotation;
    private Transform m_cameraPosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_cameraPosition = GameManager.instance.player.GetComponent<PlayerMovement>().cameraPosition;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        yRotation += mouseX;
        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(XRotation, yRotation, 0);
        m_cameraPosition.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
