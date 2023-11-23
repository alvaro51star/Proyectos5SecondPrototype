using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager2 : MonoBehaviour
{
    public UIController m_uiController;

    private int initialScene = 0;
    private int tutorialLevelScene = 1;
    private int victoryScene = 4;
    private int endScene = 5;   // el número de la última escena

    public bool isPaused = false;
    public bool islevelCompleted = false;

    private void Start()
    {
        Time.timeScale = 1;
        UIController.instance.EnabledPauseMenu(false);
        if(SceneManager.GetActiveScene().buildIndex > tutorialLevelScene && SceneManager.GetActiveScene().buildIndex < victoryScene)
        {
            UIController.instance.EnabledVictoryMenu(true);
            LevelCompleted();
        }
        else
        {
            UIController.instance.EnabledVictoryMenu(false);
        }
    }

    public void QuitGame()
    {
        // Application.Quit();
        Debug.Log("Quit Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIController.instance.EnabledInitialMenu(false);
        UIController.instance.EnabledLevelsMenu(false);
        UIController.instance.EnabledPauseMenu(false);
        UIController.instance.EnabledVictoryMenu(false);
        UIController.instance.EnabledGameOverMenu(false);
        UIController.instance.EnabledEndMenu(false);
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(initialScene);
        UIController.instance.EnabledInitialMenu(false);
        UIController.instance.EnabledLevelsMenu(true);
        UIController.instance.EnabledPauseMenu(false);
        UIController.instance.EnabledVictoryMenu(false);
        UIController.instance.EnabledGameOverMenu(false);
        UIController.instance.EnabledEndMenu(false);
    }

    public void GoToLevelsMenu()
    {
        m_uiController.CursorVisible();
        UIController.instance.EnabledInitialMenu(false);
        UIController.instance.EnabledLevelsMenu(true);
        UIController.instance.EnabledPauseMenu(false);
        UIController.instance.EnabledVictoryMenu(false);
        UIController.instance.EnabledGameOverMenu(false);
        UIController.instance.EnabledEndMenu(false);
    }

    public void GotToTutorialLevel()
    {
        m_uiController.CursorInvisible();
        SceneManager.LoadScene(tutorialLevelScene);
    }

    public void GoToEndScene()
    {
        m_uiController.CursorVisible();
        SceneManager.LoadScene(endScene);
    }
    
    public void LevelCompleted()
    {
        islevelCompleted = !islevelCompleted;

        if (islevelCompleted)
        {
            UIController.instance.CursorVisible();
            Time.timeScale = 0;
            UIController.instance.EnabledInitialMenu(false);
            UIController.instance.EnabledLevelsMenu(false);
            UIController.instance.EnabledPauseMenu(false);
            UIController.instance.EnabledVictoryMenu(true);
            UIController.instance.EnabledGameOverMenu(false);
            UIController.instance.EnabledEndMenu(false);
        }
        else
        {
            UIController.instance.CursorInvisible();
            Time.timeScale = 1;
            UIController.instance.EnabledInitialMenu(false);
            UIController.instance.EnabledLevelsMenu(false);
            UIController.instance.EnabledPauseMenu(false);
            UIController.instance.EnabledVictoryMenu(false);
            UIController.instance.EnabledGameOverMenu(false);
            UIController.instance.EnabledEndMenu(false);
        }
    }

    public void PauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            UIController.instance.CursorVisible();
            Time.timeScale = 0;
            UIController.instance.EnabledInitialMenu(false);
            UIController.instance.EnabledLevelsMenu(false);
            UIController.instance.EnabledPauseMenu(true);
            UIController.instance.EnabledVictoryMenu(false);
            UIController.instance.EnabledGameOverMenu(false);
            UIController.instance.EnabledEndMenu(false);
        }
        else
        {
            UIController.instance.CursorInvisible();
            Time.timeScale = 1;
            UIController.instance.EnabledInitialMenu(false);
            UIController.instance.EnabledLevelsMenu(false);
            UIController.instance.EnabledPauseMenu(false);
            UIController.instance.EnabledVictoryMenu(false);
            UIController.instance.EnabledGameOverMenu(false);
            UIController.instance.EnabledEndMenu(false);
        }
    }
}
