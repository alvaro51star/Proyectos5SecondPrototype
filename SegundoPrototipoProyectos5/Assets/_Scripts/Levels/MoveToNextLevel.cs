using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    [SerializeField] UI_Manager2 m_uiManager2;

    public UIController m_uiController;

    private int m_nextSceneIndex;
    private int lastLevel = 4;   // el número del último nivel

    void Start()
    {
        m_nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(SceneManager.GetActiveScene().buildIndex == lastLevel)
            {
                Debug.Log("HAS GANADO");
                // pondría otra escena que tenga el canvas diciendo enhorabuena, más niveles en el futuro.
            }
            else
            {
                if (m_nextSceneIndex > PlayerPrefs.GetInt("LevelProgress"))
                {
                    PlayerPrefs.SetInt("LevelProgress", m_nextSceneIndex);
                }
                m_uiManager2.LevelCompleted();
                SceneManager.LoadScene(m_nextSceneIndex);
            }
        }
    }
}
