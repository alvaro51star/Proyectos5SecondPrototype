using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    [SerializeField] private int lastLevel = 3;   // el número del último nivel
    private UIMenus m_UIMenus;

    private int nextSceneIndex;

    void Start()
    {
        m_UIMenus = GetComponent<UIMenus>();

        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           GoToNextLevel();
        }
    }*/

    public void GoToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == lastLevel)
        {
            Debug.Log("HAS GANADO");
            m_UIMenus.GoToEndScene();
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
