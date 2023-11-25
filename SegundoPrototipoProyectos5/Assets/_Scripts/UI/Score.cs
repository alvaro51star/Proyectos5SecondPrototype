using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{    
    [SerializeField] private CalculateSavedNPCs calculateSavedNPCs;
    [SerializeField] private CalculatePutOutFires calculatePutOutFires;

    [SerializeField, Range (0,1)] private float timeMultiplier = 0.5f;

    private UIManager m_uIManager;
    private int m_numberOfStarsWon = 0;

    private void Start()
    {
        m_uIManager = GetComponent<UIManager>();

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
        if (calculateSavedNPCs.savedVictims >= calculateSavedNPCs.totalNumberOfVictims)
            m_numberOfStarsWon += 1;
        if (calculatePutOutFires.putOutFires >= calculatePutOutFires.totalNumberOfFires)
            m_numberOfStarsWon += 1;
        if (GameManager.instance.currentTime >= GameManager.instance.maxTimeLevel * timeMultiplier)
            m_numberOfStarsWon += 1;

        m_numberOfStarsWon = Mathf.Clamp(m_numberOfStarsWon, 0, 3);
    }

    private void ActivateStars(bool b1, bool b2, bool b3)
    {
        m_uIManager.ActivateUIGameObjects(m_uIManager.firstStar, b1);
        m_uIManager.ActivateUIGameObjects(m_uIManager.secondStar, b2);
        m_uIManager.ActivateUIGameObjects(m_uIManager.thirdStar, b3);
    }
}
