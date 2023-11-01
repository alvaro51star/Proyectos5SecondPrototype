using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    private bool isTouchingGround, raycastIsGround;
    private int layerGround;
    private LayerMask groundMask;

    private void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
        layerGround = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        CheckIfItIsGrounded();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == layerGround)
        {
            isTouchingGround = true;
        }
    }

    private void CheckIfItIsGrounded()
    {
        raycastIsGround = Physics.Raycast(transform.position, Vector3.down, 0.5f, groundMask);

        if (raycastIsGround && isTouchingGround)
        {
            isGrounded = true;
        }

        else
            isGrounded = false;
    }
}
