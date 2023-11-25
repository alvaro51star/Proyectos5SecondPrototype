using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenus : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private MoveToNextLevel moveToNextLevel;
    [SerializeField] private GameObject player;
    [SerializeField] private Score score;

    private int initialScene = 0;
    private int tutorialLevelScene = 1;
    //private int congratulationsPanel = 4;
    private int endPanel = 5;   // el numero de la ultima escena

    public bool isPaused = false;
    public bool islevelCompleted = false;
    public bool isAMenuOrPanel = false;

    void Start()
    {
        if (player)
        {
            player.SetActive(true);
            isAMenuOrPanel = false;
        }

        /*if (SceneManager.GetActiveScene().buildIndex > tutorialLevelScene && SceneManager.GetActiveScene().buildIndex < congratulationsPanel)
        {
            LevelCompleted();
        }*/

        uIManager.IsInGame(true);
        uIManager.ActivateUIGameObjects(uIManager.pauseMenu, false);
    }

    public void QuitGame()
    {
        // Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(initialScene);

        uIManager.DesactivateAllUIGameObjects();
        uIManager.ActivateUIGameObjects(uIManager.initialMenu, true);
    }

    public void GoToLevelsMenu()
    {
        uIManager.IsInGame(false);
        uIManager.DesactivateAllUIGameObjects();
        uIManager.ActivateUIGameObjects(uIManager.levelsMenu, true);        
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

    /*public void LevelCompleted()    // aqui se pondria el EndGame del FinalCollider
    {
        islevelCompleted = !islevelCompleted;
        if (islevelCompleted)
        {
            isAMenuOrPanel = true;
            if (player)
            {
                player.SetActive(false);
            }

            uIManager.IsInGame(false);
            uIManager.DesactivateAllUIGameObjects();
            uIManager.ActivateUIGameObjects(uIManager.congratulationsPanel, true);
        }
        else
        {
            isAMenuOrPanel = false;
            if (player)
            {
                player.SetActive(true);
                isAMenuOrPanel = false;
            }

            uIManager.IsInGame(true);
        }
    }*/

    public void PauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            if (player)
            {
                player.SetActive(false);
                isAMenuOrPanel = true;
            }

            uIManager.IsInGame(false);
            uIManager.DesactivateAllUIGameObjects();
            uIManager.ActivateUIGameObjects(uIManager.pauseMenu, true);
        }
        else
        {
            if (player)
            {
                player.SetActive(true);
                isAMenuOrPanel = false;
            }

            Resume();
        }
    }

    public void GoToFinalScore() //para boton yes de confirmEndLevel
    {
        uIManager.ActivateUIGameObjects(uIManager.finalScore, true);
        uIManager.ActivateUIGameObjects(uIManager.confirmEndLevel, false);
        score.ShowStars();
    }

    public void Resume() //para boton no de confirmEndLevel
    {
        uIManager.DesactivateAllUIGameObjects();
        uIManager.IsInGame(true);
    }

    public void GoToNextLevel()
    {
        moveToNextLevel.GoToNextLevel();
    }
}
