using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNPC : MonoBehaviour
{
    private bool pickedUp = false;
    [SerializeField] private Transform pickUpPosition;
    private Rigidbody rb;
    [SerializeField] private float force = 10;
    private ParachuteBehaviour parachuteBehaviour;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        parachuteBehaviour = GetComponent<ParachuteBehaviour>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.E) && other.gameObject.CompareTag("Player") && !pickedUp)
        {
            parachuteBehaviour.enabled = false;
            rb.useGravity = false;
            transform.SetParent(pickUpPosition);
            ResetTransform();
            pickedUp = true;
        }

        if (pickedUp && Input.GetKey(KeyCode.G))
        {
            parachuteBehaviour.enabled = true;
            pickUpPosition.DetachChildren();
            rb.useGravity = true;
            rb.AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
            pickedUp = false;

        }
    }

    private void ResetTransform()
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
    }
}
