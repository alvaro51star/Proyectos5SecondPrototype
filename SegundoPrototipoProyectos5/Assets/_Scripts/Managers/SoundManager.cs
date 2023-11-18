using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioClipsNames
{
    
}


public class SoundManager : MonoBehaviour
{

    [SerializeField] private List<AudioClip> soundList;

    public static SoundManager instance;
    [SerializeField] private AudioSource managerAudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReproduceSound(AudioClipsNames clipName, AudioSource audioSource)
    {
        audioSource.PlayOneShot(soundList[(int)clipName]);
    }

    public void ReproduceSound(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void ReproduceSound(AudioClip audioClip)
    {
        managerAudioSource.PlayOneShot(audioClip);
    }

    public void ReproduceSound(AudioClipsNames clipName)
    {
        managerAudioSource.PlayOneShot(instance.soundList[(int)clipName]);
    }
}
