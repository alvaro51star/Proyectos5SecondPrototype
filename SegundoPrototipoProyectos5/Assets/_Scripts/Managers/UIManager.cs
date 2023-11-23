using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public static UIController instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject exitLevelMenu;
    [SerializeField] private GameObject finalScore;

    public GameObject initialMenu;
    public GameObject levelsMenu;
    public GameObject pauseMenu;
    public GameObject congratulationsPanel;
    public GameObject gameOverPanel2;
    public GameObject endPanel;

    public void MenusAndPanels (GameObject gOToActivate, bool b)
    {
        gOToActivate.SetActive(b);
    }

    /*
    public void EnabledInitialMenu(bool isActive)
    {
        initialMenu.SetActive(isActive);
    }

    public void EnabledLevelsMenu(bool isActive)
    {
        levelsMenu.SetActive(isActive);
    }

    public void EnabledPauseMenu(bool isActive)
    {
        pauseMenu.SetActive(isActive);
    }
    public void EnabledCongratulationsPanel(bool isActive)
    {
        congratulationsPanel.SetActive(isActive);
    }

    public void EnabledGameOverMenu(bool isActive)
    {
        gameOverPanel2.SetActive(isActive);
    }
    */

    public void EnabledEndMenu(bool isActive)
    {
        endPanel.SetActive(isActive);
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        IsInGame(false);
        gameOverPanel.SetActive(true);
    }

    public void EndGame ()
    {
        IsInGame(false);
        exitLevelMenu.SetActive(true);
    }

    public void FinalScore()
    {
        finalScore.SetActive(true);
        exitLevelMenu.SetActive(false);
    }

    public void IsInGame (bool isInGame)
    {
        if(isInGame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
