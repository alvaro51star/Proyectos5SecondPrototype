using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSounds : MonoBehaviour
{
    [SerializeField] private Fire fire;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int sizeMultiplier = 20;

    private void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = fire.boxCollider.size * sizeMultiplier;
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
                    SoundManager.instance.ReproduceSound(AudioClipsNames.Fire_1, audioSource);
                }
                else
                {
                    SoundManager.instance.ReproduceSound(AudioClipsNames.Fire_2, audioSource);
                }
            }            
        }        
    }
}
