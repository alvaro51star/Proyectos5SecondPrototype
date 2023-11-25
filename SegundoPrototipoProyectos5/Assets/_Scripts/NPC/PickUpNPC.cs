using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Buffers.Text;

public class PickUpNPC : InteractiveObject
{
    private bool pickedUp = false;
    [SerializeField] private Transform pickUpPosition;
    private Rigidbody rb;
    [SerializeField] private float force = 10;
    private ParachuteBehaviour parachuteBehaviour;
    [SerializeField] private PlayerManager playerManager;

    LayerMask groundLayer = 6;
    [SerializeField] private MeshCollider meshColliderNPC;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        parachuteBehaviour = GetComponent<ParachuteBehaviour>();
    }

    protected override void OnTriggerEnter(Collider other) {
        if(pickedUp == false){
            base.OnTriggerEnter(other);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerManager = other.GetComponent<PlayerManager>();
        }

        if (Input.GetKey(KeyCode.E) && other.gameObject.CompareTag("Player") && !pickedUp && !playerManager.HasBody())
        {
            parachuteBehaviour.enabled = false;
            rb.useGravity = false;
            meshColliderNPC.enabled = false;
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
            meshColliderNPC.enabled = true;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            pickedUp = false;

        }
    }

    private void ResetTransform()
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
    }
}
