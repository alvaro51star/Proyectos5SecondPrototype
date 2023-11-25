using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSavedNPCs : MonoBehaviour
{
    [SerializeField] private GameObject[] victims;
    public int totalNumberOfVictims;
    private void Start()
    {
        totalNumberOfVictims = victims.Length;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {

        }
    }
}
