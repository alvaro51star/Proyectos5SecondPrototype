using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject exitLevelMenu;
    [SerializeField] private GameObject finalScore;

    public GameObject initialMenu;
    public GameObject levelsMenu;
    public GameObject pauseMenu;
    public GameObject congratulationsPanel;
    public GameObject gameOverPanel;
    public GameObject endPanel;

    public bool dead = false;

    public void ActivateUIGameObjects(GameObject gOToActivate, bool b)
    {
        gOToActivate.SetActive(b);
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
        dead = true;
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
