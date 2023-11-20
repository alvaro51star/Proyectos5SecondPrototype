using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public UIController m_uiController;

    private int m_nextSceneIndex;
    private int lastLevel = 4;   // el n�mero del �ltimo nivel
    private int victoryScene = 5;   // o el que sea seg�n el n�mero de niveles

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
                // pondr�a otra escena que tenga el canvas diciendo enhorabuena, m�s niveles en el futuro.
            }
            else
            {
                //UIController.instance.CursorVisible();
                //SceneManager.LoadScene(victoryScene);
                if (m_nextSceneIndex > PlayerPrefs.GetInt("LevelProgress"))
                {
                    PlayerPrefs.SetInt("LevelProgress", m_nextSceneIndex);
                }
                SceneManager.LoadScene(m_nextSceneIndex);
            }
        }
    }
}
