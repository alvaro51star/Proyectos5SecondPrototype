using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteraction : InteractiveObject
{

    public delegate void OnCatInteractionDelegate();
    public static event OnCatInteractionDelegate OnCatPet;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject heartImage;

    [SerializeField] private float timeToPetAgain = 1f;
    private bool recentActivated = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !recentActivated)
        {
            recentActivated = true;
            StartCoroutine(SetBoolFalse(timeToPetAgain));
            SoundManager.instance.ReproduceSound(AudioClipsNames.CatMeow, audioSource);
            ShowImage();
            if(OnCatPet != null){
                OnCatPet();
            }
        }
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
