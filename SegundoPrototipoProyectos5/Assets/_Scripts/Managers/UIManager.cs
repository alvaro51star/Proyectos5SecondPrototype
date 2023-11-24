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
    public void MenusAndPanels(GameObject gOToActivate, bool b)
    {
        gOToActivate.SetActive(b);
    }
    // TODO: Poner la imagen en el canvas y activarla y desactivarla
    private void EnableImage()
    {
        Debug.Log("Dentro");
    }

    private void DisableImage()
    {
        Debug.Log("Fuera");
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

>>>>>>> Stashed changes
    private void OnEnable()
    {
        GameManager.OnGameOver += ShowGameOver;
        InteractiveObject.OnPlayerInside += EnableImage;
        InteractiveObject.OnPlayerOutSide += DisableImage;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= ShowGameOver;
        InteractiveObject.OnPlayerInside -= EnableImage;
        InteractiveObject.OnPlayerOutSide -= DisableImage;
    }

    private void ShowGameOver()
    {
        IsInGame(false);
        gameOverPanel.SetActive(true);
        dead = true;
    }

    {
        IsInGame(false);
        exitLevelMenu.SetActive(true);
    }

    public void FinalScore()
    {
        finalScore.SetActive(true);
        exitLevelMenu.SetActive(false);
    }

    {
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
