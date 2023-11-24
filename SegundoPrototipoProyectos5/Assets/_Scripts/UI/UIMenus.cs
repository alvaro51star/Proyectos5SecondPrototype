using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenus : MonoBehaviour
{
    public UIManager uIManager;
    [SerializeField] GameObject player;

    private int initialScene = 0;
    private int tutorialLevelScene = 1;
    private int congratulationsPanel = 4;
    private int endPanel = 5;   // el n�mero de la �ltima escena

    public bool isPaused = false;
    public bool islevelCompleted = false;

    void Start()
    {
        Time.timeScale = 1;
        if (player)
        {
            player.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex > tutorialLevelScene && SceneManager.GetActiveScene().buildIndex < congratulationsPanel)
        {
            uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, true);
            LevelCompleted();
        }
        else
        {
            uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
        }

        uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
        uIManager.dead = false;
    }

    public void QuitGame()
    {
        // Application.Quit();
        Debug.Log("Quit Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        uIManager.ActivateUIGameObjects(uIManager.initialMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.levelsMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
        uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
        uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(initialScene);
        uIManager.ActivateUIGameObjects(uIManager.initialMenu, true);
        uIManager.ActivateUIGameObjects(uIManager.levelsMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
        uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
        uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
    }

    public void GoToLevelsMenu()
    {
        uIManager.IsInGame(false);
        uIManager.ActivateUIGameObjects(uIManager.initialMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.levelsMenu, true);
        uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
        uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
        uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
        uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
    }

    public void GotToTutorialLevel()
    {
        uIManager.IsInGame(true);
        SceneManager.LoadScene(tutorialLevelScene);
    }

    public void GoToEndScene()
    {
        uIManager.IsInGame(false);
        SceneManager.LoadScene(endPanel);
    }

    public void LevelCompleted()    // aqui se pondria el EndGame del FinalCollider
    {
        islevelCompleted = !islevelCompleted;
        if (islevelCompleted)
        {
            if (player)
            {
                player.SetActive(false);
            }

            uIManager.IsInGame(false);
            Time.timeScale = 0;
            uIManager.ActivateUIGameObjects(uIManager.initialMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.levelsMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, true);
            uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
            uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
            uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
        }
        else
        {
            if (player)
            {
                player.SetActive(true);
            }
            uIManager.IsInGame(true);
            Time.timeScale = 1;
            uIManager.ActivateUIGameObjects(uIManager.initialMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.levelsMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
            uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
            uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
        }
    }

    public void PauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            if (player)
            {
                player.SetActive(false);
            }

            uIManager.IsInGame(false);
            Time.timeScale = 0;
            uIManager.ActivateUIGameObjects(uIManager.initialMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.levelsMenu, false);
            uIManager.ActivateUIGameObjects(uIManager.pauseMenu, true);
            uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
            uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
            uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
        }
        else
        {
            if (player)
            {
                player.SetActive(true);
            }

            if (uIManager.dead == true)
            {
                Debug.Log("Estas muerto, no hay resume");
            }
            else
            {
                uIManager.IsInGame(true);
                Time.timeScale = 1;
                uIManager.ActivateUIGameObjects(uIManager.initialMenu, false);
                uIManager.ActivateUIGameObjects(uIManager.levelsMenu, false);
                uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
                uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, false);
                uIManager.ActivateUIGameObjects(uIManager.gameOverPanel, false);
                uIManager.ActivateUIGameObjects(uIManager.endPanel, false);
            }
        }
    }
}
