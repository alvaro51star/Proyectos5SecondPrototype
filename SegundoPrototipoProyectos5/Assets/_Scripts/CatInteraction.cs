using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteraction : InteractiveObject
{

    public delegate void OnCatInteractionDelegate();
    public static event OnCatInteractionDelegate OnCatPet;

    AudioSource audioSource;
    [SerializeField] private AudioClip catSound;
    [SerializeField] private GameObject heartImage;

    [SerializeField] private float timeToPetAgain = 1f;
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
            StartCoroutine(SetBoolFalse(timeToPetAgain));
            ReproduceCatSound();
            ShowImage();
            if(OnCatPet != null){
                OnCatPet();
            }
        }
    }

    private void ReproduceCatSound()
    {
        //!SoundManager.instance.ReproduceSound(catSound, audioSource);
    }

    private void ShowImage()
    {
        heartImage.SetActive(true);
        StartCoroutine(DisableImage(timeToPetAgain));
    }

    private IEnumerator DisableImage(float time)
    {
        yield return new WaitForSeconds(time);
        heartImage.SetActive(false);
    }

    private IEnumerator SetBoolFalse(float time)
    {
        yield return new WaitForSeconds(time);
        recentActivated = false;
    }
}
