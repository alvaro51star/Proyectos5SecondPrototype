using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteraction : InteractiveObject
{

    public delegate void OnCatInteractionDelegate();
    public static event OnCatInteractionDelegate OnCatPet;

    AudioSource audioSource;
    [SerializeField] private AudioClip catSound;

    [SerializeField] private float timeToSwitchAgain = 1f;
    private bool recentActivated = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !recentActivated)
        {
            recentActivated = true;
            StartCoroutine(SetBoolFalse(timeToSwitchAgain));
            if (OnCatPet != null)
                OnCatPet();
        }
    }

    private void OnEnable()
    {
        OnCatPet += ReproduceCatSound;
    }

    private void OnDisable()
    {
        OnCatPet -= ReproduceCatSound;
    }

    private void ReproduceCatSound()
    {
        SoundManager.instance.ReproduceSound(catSound, audioSource);
    }

    private IEnumerator SetBoolFalse(float time)
    {
        yield return new WaitForSeconds(time);
        recentActivated = false;
    }
}
