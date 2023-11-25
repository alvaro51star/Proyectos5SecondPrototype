using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenus : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    
    private Score m_Score;
    private UIManager m_UIManager;
    private MoveToNextLevel m_MoveToNextLevel;
    private int m_initialScene = 0;
    private int m_tutorialLevelScene = 1;
    //private int congratulationsPanel = 4;
    private int m_endPanel = 5;   // el numero de la ultima escena

    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public bool islevelCompleted = false;
    [HideInInspector] public bool isAMenuOrPanel = false;

    void Start()
    {
        m_UIManager = GetComponent<UIManager>();
        m_MoveToNextLevel = GetComponent<MoveToNextLevel>();
        m_Score = GetComponent<Score>();

        if (player)
        {
            player.SetActive(true);
            isAMenuOrPanel = false;
        }

        /*if (SceneManager.GetActiveScene().buildIndex > tutorialLevelScene && SceneManager.GetActiveScene().buildIndex < congratulationsPanel)
        {
            LevelCompleted();
        }*/

        m_UIManager.IsInGame(true);
        m_UIManager.ActivateUIGameObjects(m_UIManager.pauseMenu, false);
    }

    public void QuitGame()
    {
        // Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(m_initialScene);

        m_UIManager.DesactivateAllUIGameObjects();
        m_UIManager.ActivateUIGameObjects(m_UIManager.initialMenu, true);
    }

    public void GoToLevelsMenu()
    {
        m_UIManager.IsInGame(false);
        m_UIManager.DesactivateAllUIGameObjects();
        m_UIManager.ActivateUIGameObjects(m_UIManager.levelsMenu, true);        
    }

    public void GotToTutorialLevel()
    {
        m_UIManager.IsInGame(true);
        SceneManager.LoadScene(m_tutorialLevelScene);
    }

    public void GoToEndScene()
    {
        m_UIManager.IsInGame(false);
        SceneManager.LoadScene(m_endPanel);
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

            m_UIManager.IsInGame(false);
            m_UIManager.DesactivateAllUIGameObjects();
            m_UIManager.ActivateUIGameObjects(m_UIManager.pauseMenu, true);
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
        m_UIManager.ActivateUIGameObjects(m_UIManager.finalScore, true);
        m_UIManager.ActivateUIGameObjects(m_UIManager.confirmEndLevel, false);
        m_Score.ShowStars();
    }

    public void Resume() //para boton no de confirmEndLevel y para dontAllowToLeaveLevel
    {
        m_UIManager.DesactivateAllUIGameObjects();
        m_UIManager.IsInGame(true);
    }

    public void GoToNextLevel()
    {
        m_MoveToNextLevel.GoToNextLevel();
    }
}
