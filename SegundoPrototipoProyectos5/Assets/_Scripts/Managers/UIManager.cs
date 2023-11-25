using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject confirmEndLevel;
    public GameObject finalScore;
    public GameObject initialMenu;
    public GameObject levelsMenu;
    public GameObject pauseMenu;
    //public GameObject congratulationsPanel;
    public GameObject gameOverPanel;
    public GameObject endPanel;

    [SerializeField] private GameObject[] UIGameObjects;

    public bool dead = false;


    public void ActivateUIGameObjects(GameObject gOToActivate, bool b)
    {
        gOToActivate.SetActive(b);
    }
    public void DesactivateAllUIGameObjects()
    {
        for (int i = 0; i < UIGameObjects.Length; i++)
        {
            UIGameObjects[i].SetActive(false);
        }
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
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
}
