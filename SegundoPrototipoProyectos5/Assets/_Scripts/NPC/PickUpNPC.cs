using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNPC : MonoBehaviour
{
    private bool pickedUp = false;
    [SerializeField] private Transform pickUpPosition;
    private Rigidbody rb;
    [SerializeField] private float force = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.E) && other.gameObject.CompareTag("Player") && !pickedUp)
        {
            rb.useGravity = false;
            transform.SetParent(pickUpPosition);
            ResetTransform();
            pickedUp = true;
            Debug.Log("Lo pillaste");
        }

        if (pickedUp && Input.GetKey(KeyCode.G))
        {
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
