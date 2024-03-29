using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraPlayer;
    [HideInInspector] public AudioSource audioSourceUI;
    [SerializeField] private CalculatePutOutFires calculatePutOutFires;

    [Header("Canvas menus and panels")]
    public GameObject confirmEndLevel;
    public GameObject finalScore;
    public GameObject initialMenu;
    public GameObject levelsMenu;
    public GameObject pauseMenu;
    public GameObject gameOverPanel;
    public GameObject endPanel;
    public GameObject dontAllowToLeaveLevelPanel;
    public GameObject dialoguePanel;
    [SerializeField] private GameObject EImage;
    [SerializeField] private GameObject permanentIcons;

    [Header("Put same things here:")]
    [SerializeField] private GameObject[] MenusAndPanels;

    [Header("Score stars")]
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;

    [HideInInspector] public bool dead = false;

    private void Start()
    {
        audioSourceUI = GetComponent<AudioSource>();
    }
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
        EImage.SetActive(true);
    }

    private void DisableImage()
    {
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
        DesactivateAllUIGameObjects();
        SoundManager.instance.ReproduceSound(AudioClipsNames.GameOver, audioSourceUI);
        gameOverPanel.SetActive(true);
        dead = true;
    }

    public void IsInGame(bool isInGame)
    {
        if (isInGame)
        {
            if (player != null)
            {
                player.SetActive(true);
            }
            if (cameraPlayer != null)
            {
                cameraPlayer.GetComponent<CameraRotation>().enabled = true;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;

            DesactivateAllUIGameObjects();
            permanentIcons.SetActive(true);
        }
        else
        {
            if (player != null)
            {
                player.SetActive(false);
            }
            if (cameraPlayer != null)
            {
                cameraPlayer.GetComponent<CameraRotation>().enabled = false;
            }

            if(calculatePutOutFires != null)
            {
                if (calculatePutOutFires.putOutFires != calculatePutOutFires.totalNumberOfFires)
                {
                    calculatePutOutFires.DesactivateFireSounds();
                }
            }
         
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
}
