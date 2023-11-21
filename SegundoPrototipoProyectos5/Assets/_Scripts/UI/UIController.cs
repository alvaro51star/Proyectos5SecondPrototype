using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject m_initialMenu;
    public GameObject m_levelsMenu;
    public GameObject m_pauseMenu;
    public GameObject m_victoryMenu;
    public GameObject m_gameOverMenu;
    public GameObject m_endMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnabledInitialMenu(bool isActive)
    {
        m_initialMenu.SetActive(isActive);
    }

    public void EnabledLevelsMenu(bool isActive)
    {
        m_levelsMenu.SetActive(isActive);
    }

    public void EnabledPauseMenu(bool isActive)
    {
        m_pauseMenu.SetActive(isActive);
    }
    public void EnabledVictoryMenu(bool isActive)
    {
        m_victoryMenu.SetActive(isActive);
    }

    public void EnabledGameOverMenu(bool isActive)
    {
        m_gameOverMenu.SetActive(isActive);
    }

    public void EnabledEndMenu(bool isActive)
    {
        m_endMenu.SetActive(isActive);
    }

    public void CursorVisible()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void CursorInvisible()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
