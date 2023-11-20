using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;

    private void Start()
    {
        //cameraPosition = GameManager.instance.player.GetComponent<PlayerMovement>().cameraPosition;
    }
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
