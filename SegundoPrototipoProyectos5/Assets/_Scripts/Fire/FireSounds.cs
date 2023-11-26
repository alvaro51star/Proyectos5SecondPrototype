using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSounds : MonoBehaviour
{
    [SerializeField] private Fire fire;
    [SerializeField] private int sizeMultiplier = 50;
    private AudioSource m_audioSource;

    private void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = fire.boxCollider.size * sizeMultiplier;
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.maxDistance = sizeMultiplier;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!m_audioSource.isPlaying)
            {
                int clip = Random.Range(0, 1);

                if (clip == 0)
                {
                    SoundManager.instance.ReproduceSound(AudioClipsNames.Fire_1, m_audioSource);
                }
                else
                {
                    SoundManager.instance.ReproduceSound(AudioClipsNames.Fire_2, m_audioSource);
                }
            }            
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_audioSource.isPlaying)
            {
                m_audioSource.Stop();
            }
        }
    }
}
