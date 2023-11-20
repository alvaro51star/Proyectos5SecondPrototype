using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager2 : MonoBehaviour
{
    [SerializeField] NextSceneIndex nextSceneIndex;

    public UIController m_uiController;

    private int initialScene = 0;
    private int levelSelectionScene = 1;
    private int tutorialLevelScene = 2;
    private int m_nextSceneIndex;

    public bool isPaused = false;

    private void Start()
    {
        UIController.instance.EnabledPauseMenu(false);
        m_nextSceneIndex = nextSceneIndex.nextSceneLoad;
    }

    public void QuitGame()
    {
        // Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(initialScene);
    }

    public void GoToLevelsMenu()
    {
        m_uiController.CursorVisible();
        SceneManager.LoadScene(levelSelectionScene);
    }

    public void GotToTutorialLevel()
    {
        m_uiController.CursorInvisible();
        SceneManager.LoadScene(tutorialLevelScene);
    }

    /* public void GoToNextLevel()
    {
        if (m_nextSceneIndex > PlayerPrefs.GetInt("LevelProgress"))
        {
            PlayerPrefs.SetInt("LevelProgress", m_nextSceneIndex);
        }
        SceneManager.LoadScene(m_nextSceneIndex);
    } */
    
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
        }
    }
}
