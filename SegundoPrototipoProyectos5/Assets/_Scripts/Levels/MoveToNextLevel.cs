using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public UIController m_uiController;
    //private int nextSceneLoad;
    private int lastLevel = 2;   // el número del último nivel

    private int victoryScene = 3;   // o el que sea según el número de niveles

    // Start is called before the first frame update
    void Start()
    {
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
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
                m_uiController.CursorInvisible();
                SceneManager.LoadScene(victoryScene);
            }
        }
    }
}
