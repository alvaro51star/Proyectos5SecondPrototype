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
    private int endPanel = 5;   // el número de la última escena

    public bool isPaused = false;
    public bool islevelCompleted = false;

    void Start()
    {
        Time.timeScale = 1;
        if (player)
        {
            player.SetActive(true);
        }
        uIManager.MenusAndPanels(uIManager.pauseMenu, false);
        if (SceneManager.GetActiveScene().buildIndex > tutorialLevelScene && SceneManager.GetActiveScene().buildIndex < congratulationsPanel)
        {
            uIManager.MenusAndPanels(uIManager.congratulationsPanel, true);
            LevelCompleted();
        }
        else
        {
            uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
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
        uIManager.MenusAndPanels(uIManager.initialMenu, false);
        uIManager.MenusAndPanels(uIManager.levelsMenu, false);
        uIManager.MenusAndPanels(uIManager.pauseMenu, false);
        uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
        // si es necesario, desactivar el game over tmb
        uIManager.MenusAndPanels(uIManager.endPanel, false);
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(initialScene);
        uIManager.MenusAndPanels(uIManager.initialMenu, true);
        uIManager.MenusAndPanels(uIManager.levelsMenu, false);
        uIManager.MenusAndPanels(uIManager.pauseMenu, false);
        uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
        // si es necesario, desactivar el game over tmb
        uIManager.MenusAndPanels(uIManager.endPanel, false);
    }

    public void GoToLevelsMenu()
    {
        Debug.Log("ir al menu de niveles");
        uIManager.IsInGame(false);
        uIManager.MenusAndPanels(uIManager.initialMenu, false);
        uIManager.MenusAndPanels(uIManager.levelsMenu, true);
        uIManager.MenusAndPanels(uIManager.pauseMenu, false);
        uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
        // si es necesario, desactivar el game over tmb
        uIManager.MenusAndPanels(uIManager.endPanel, false);
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

    public void LevelCompleted()    // aquí se pondría el EndGame del FinalCollider
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
            uIManager.MenusAndPanels(uIManager.initialMenu, false);
            uIManager.MenusAndPanels(uIManager.levelsMenu, false);
            uIManager.MenusAndPanels(uIManager.pauseMenu, false);
            uIManager.MenusAndPanels(uIManager.congratulationsPanel, true);
            // si es necesario, desactivar el game over tmb
            uIManager.MenusAndPanels(uIManager.endPanel, false);
        }
        else
        {
            if (player)
            {
                player.SetActive(true);
            }
            uIManager.IsInGame(true);
            Time.timeScale = 1;
            uIManager.MenusAndPanels(uIManager.initialMenu, false);
            uIManager.MenusAndPanels(uIManager.levelsMenu, false);
            uIManager.MenusAndPanels(uIManager.pauseMenu, false);
            uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
            // si es necesario, desactivar el game over tmb
            uIManager.MenusAndPanels(uIManager.endPanel, false);
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
            uIManager.MenusAndPanels(uIManager.initialMenu, false);
            uIManager.MenusAndPanels(uIManager.levelsMenu, false);
            uIManager.MenusAndPanels(uIManager.pauseMenu, true);
            uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
            // si es necesario, desactivar el game over tmb
            uIManager.MenusAndPanels(uIManager.endPanel, false);
        }
        else
        {
            if (player)
            {
                player.SetActive(true);
            }

            uIManager.IsInGame(true);
            Time.timeScale = 1;
            uIManager.MenusAndPanels(uIManager.initialMenu, false);
            uIManager.MenusAndPanels(uIManager.levelsMenu, false);
            uIManager.MenusAndPanels(uIManager.pauseMenu, false);
            uIManager.MenusAndPanels(uIManager.congratulationsPanel, false);
            // si es necesario, desactivar el game over tmb
            uIManager.MenusAndPanels(uIManager.endPanel, false);
        }
    }
}
