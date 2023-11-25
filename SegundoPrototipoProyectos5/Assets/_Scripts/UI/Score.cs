using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UIManager uImanager;
    [SerializeField] private CalculateSavedNPCs calculateSavedNPCs;

    [SerializeField, Range (0,1)] private float timeMultiplier = 0.5f;
    private int m_victimsSaved;
    private int m_totalNumberOfFires;
    private int m_firesPutOut;
    private int m_numberOfStarsWon = 0;

    private void Start()
    {
        ActivateStars(false, false, false);
    }

    public void ShowStars()
    {
        CalculateScore();

        if(m_numberOfStarsWon == 1)
        {
            ActivateStars(true, false, false);
        }
        else if(m_numberOfStarsWon == 2)
        {
            ActivateStars(true, true, false);
        }
        else if (m_numberOfStarsWon == 3)
        {
            ActivateStars(true, true, true);
        }
        else
        {
            ActivateStars(false, false, false);
        }
    }
    private void CalculateScore()
    {
        if (m_victimsSaved >= calculateSavedNPCs.totalNumberOfVictims)
            m_numberOfStarsWon += 1;
        if (m_firesPutOut >= m_totalNumberOfFires)
            m_numberOfStarsWon += 1;
        if (GameManager.instance.currentTime >= GameManager.instance.maxTimeLevel * timeMultiplier)
            m_numberOfStarsWon += 1;

        m_numberOfStarsWon = Mathf.Clamp(m_numberOfStarsWon, 0, 3);
    }

    private void ActivateStars(bool b1, bool b2, bool b3)
    {
        uImanager.ActivateUIGameObjects(uImanager.firstStar, b1);
        uImanager.ActivateUIGameObjects(uImanager.secondStar, b2);
        uImanager.ActivateUIGameObjects(uImanager.thirdStar, b3);
    }
}
