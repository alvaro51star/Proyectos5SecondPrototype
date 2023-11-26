using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioClipsNames
{
    CatMeow,
    Fire_1,
    Fire_2,
    FireDying_1,
    FireDying_2,
    GameOver,
    Grunt_1,
    Grunt_2,
    Grunt_4,
    Jump_01,
    Jump_02,
    Jump_03,
    Landing_01,
    Landing_02,
    Reload,
    WaterGround,
    Click,
    Click_01,
    Pop,
    Pop2,
    Pop3,
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

    public void ReproduceSound(AudioClipsNames clipName)
    {
        managerAudioSource.PlayOneShot(instance.soundList[(int)clipName]);
    }

    public void ReproduceSound(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void ReproduceSound(AudioClip audioClip)
    {
        managerAudioSource.PlayOneShot(audioClip);
    }

}
