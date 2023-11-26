using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSavedNPCs : MonoBehaviour
{
    [SerializeField]  private GameObject[] victims;
    [SerializeField] private Icons icons;
    private int m_totalNumberOfVictims;
    private int m_savedVictims = 0;
    [HideInInspector] public bool everyoneHasBeenSaved;
    private void Start()
    {
        m_totalNumberOfVictims = victims.Length;
        icons.SetMaxNumber(m_totalNumberOfVictims, icons.maxNumberVictims);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            m_savedVictims += 1;
            m_savedVictims = Mathf.Clamp(m_savedVictims, 0, m_totalNumberOfVictims);
            other.tag = "Untagged";
            icons.ChangeNumber(m_savedVictims, icons.numberVictimsLeft);

            if(m_savedVictims >= m_totalNumberOfVictims)
            {
                everyoneHasBeenSaved = true;
                SoundManager.instance.ReproduceSound(AudioClipsNames.AllVictimsSaved);
            }
        }
    }
}
