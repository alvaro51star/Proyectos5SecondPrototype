using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    //[SerializeField] private GameObject pauseMenu;
    //[SerializeField] private GameObject congratulationsPanel;
    [SerializeField] private GameObject exitLevelMenu;
    [SerializeField] private GameObject finalScore;


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

    private void IsInGame (bool isInGame)
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
