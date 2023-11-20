using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    //[SerializeField] private GameObject pauseMenu;
    //[SerializeField] private GameObject congratulationsPanel;
    //[SerializeField] private GameObject exitLevelMenu;

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
        gameOverPanel.SetActive(true);
    }
}
