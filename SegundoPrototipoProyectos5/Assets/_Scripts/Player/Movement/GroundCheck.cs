using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [HideInInspector] public bool isGrounded = false;
    private bool isTouchingGround, raycastIsGround = false;
    private int layerGround;
    private LayerMask groundMask;

    private void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
        layerGround = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        raycastIsGround = Physics.Raycast(transform.position, Vector3.down, 0.5f, groundMask);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(raycastIsGround && isTouchingGround)
        {
            isGrounded = true;
        }
            
        else
            isGrounded = false;        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == layerGround)
        {
            isTouchingGround = true;

            if (!audioSource.isPlaying)
            {
                SoundManager.instance.ReproduceSound(AudioClipsNames.Landing_02, audioSource);
            }            
        }
    }
}
