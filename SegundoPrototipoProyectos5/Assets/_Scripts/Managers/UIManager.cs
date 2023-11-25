using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas menus and panels")]
    public GameObject confirmEndLevel;
    public GameObject finalScore;
    public GameObject initialMenu;
    public GameObject levelsMenu;
    public GameObject pauseMenu;
    //public GameObject congratulationsPanel;
    public GameObject gameOverPanel;
    public GameObject endPanel;
    [SerializeField] private GameObject EImage;
    [SerializeField] private GameObject timerBar;

    [Header("Put same things here:")]
    [SerializeField] private GameObject[] MenusAndPanels;

    [Header("Score stars")]
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;

    [HideInInspector] public bool dead = false;

    public void ActivateUIGameObjects(GameObject gOToActivate, bool b)
    {
        gOToActivate.SetActive(b);
    }
    public void DesactivateAllUIGameObjects()
    {
        for (int i = 0; i < MenusAndPanels.Length; i++)
        {
            MenusAndPanels[i].SetActive(false);
        }
    }

    // TODO: Poner la imagen en el canvas y activarla y desactivarla
    private void EnableImage()
    {
        Debug.Log("Dentro");
        EImage.SetActive(true);
    }

    private void DisableImage()
    {
        Debug.Log("Fuera");
        EImage.SetActive(false);
    }

    public void EnabledEndMenu(bool isActive)
    {
        endPanel.SetActive(isActive);
    }


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

    public void IsInGame (bool isInGame)
    {
        if(isInGame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            DesactivateAllUIGameObjects();
            timerBar.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
}
