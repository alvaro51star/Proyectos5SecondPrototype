using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    public UIMenus uiMenus;

    private int nextSceneIndex;
    private int lastLevel = 3;   // el número del último nivel

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(SceneManager.GetActiveScene().buildIndex == lastLevel)
            {
                Debug.Log("HAS GANADO");
                uiMenus.GoToEndScene();
            }
            else
            {
                if (nextSceneIndex > PlayerPrefs.GetInt("LevelProgress"))
                {
                    PlayerPrefs.SetInt("LevelProgress", nextSceneIndex);
                }
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
