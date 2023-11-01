using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Transform m_cameraPosition;

    private void Start()
    {
        m_cameraPosition = GameManager.instance.player.GetComponent<PlayerMovement>().cameraPosition;
    }
    private void Update()
    {
        transform.position = m_cameraPosition.position;
    }
}
