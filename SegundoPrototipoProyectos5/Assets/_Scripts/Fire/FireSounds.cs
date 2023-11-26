using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSounds : MonoBehaviour
{
    [SerializeField] private Fire fire;
    [SerializeField] private int sizeMultiplier = 50;

    [HideInInspector] public AudioSource audioSource;

    private void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = fire.boxCollider.size * sizeMultiplier;
        audioSource = GetComponent<AudioSource>();
        audioSource.maxDistance = sizeMultiplier;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!audioSource.isPlaying)
            {
                int clip = Random.Range(0, 1);

                if (clip == 0)
                {

                    SoundManager.instance.Reproduce3DSound(AudioClipsNames.Fire_1, audioSource);
                }
                else
                {
                    SoundManager.instance.Reproduce3DSound(AudioClipsNames.Fire_1, audioSource);
                }
            }            
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
