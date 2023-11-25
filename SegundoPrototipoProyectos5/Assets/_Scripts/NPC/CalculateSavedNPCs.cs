using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSavedNPCs : MonoBehaviour
{
    [SerializeField]  private GameObject[] victims;
    private int m_totalNumberOfVictims;
    private int m_savedVictims = 0;
    [HideInInspector] public bool everyoneHasBeenSaved;
    private void Start()
    {
        m_totalNumberOfVictims = victims.Length;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            Debug.Log("NPC toca el suelo");
            m_savedVictims += 1;
            m_savedVictims = Mathf.Clamp(m_savedVictims, 0, m_totalNumberOfVictims);
            other.tag = "Untagged";
            Debug.Log("saved victims:  " + m_savedVictims +"/" + m_totalNumberOfVictims);

            if(m_savedVictims >= m_totalNumberOfVictims)
            {
                Debug.Log("Enhorabuena, has salvado a todos");
                everyoneHasBeenSaved = true;
                //SoundManager.instance.ReproduceSound();
            }
        }
    }
}