using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSavedNPCs : MonoBehaviour
{
    [SerializeField]  private GameObject[] victims;
    [HideInInspector] public int totalNumberOfVictims;
    [HideInInspector] public int savedVictims = 0;
    private void Start()
    {
        totalNumberOfVictims = victims.Length;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            Debug.Log("NPC toca el suelo");
            savedVictims += 1;
            savedVictims = Mathf.Clamp(savedVictims, 0, totalNumberOfVictims);
            other.tag = "Untagged";
            Debug.Log("saved victims:  " + savedVictims +"/" + totalNumberOfVictims);

            if(savedVictims >= totalNumberOfVictims)
            {
                Debug.Log("Enhorabuena, has salvado a todos");
                //SoundManager.instance.ReproduceSound();
            }
        }
    }
}
