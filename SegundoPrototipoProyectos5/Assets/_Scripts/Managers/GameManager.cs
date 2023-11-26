using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Events
    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public delegate void OnVariableChangeDelegate(float newVal);
    public static event OnVariableChangeDelegate OnTimeChange;

    public int timesCatBeenPet = 0;

    public GameObject player;
    public bool gameStarts = true;

    [SerializeField] public float maxTimeLevel;
    [HideInInspector] public float currentTime;
    private float tempTime;

    private bool isDone = false;


    private void Start()
    {
        currentTime = maxTimeLevel;
        tempTime = currentTime;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime <= 0 && !isDone)
        {
            currentTime = 0;
            isDone = true;
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }

        CheckTimerValueChange();
    }

    private void CheckTimerValueChange()
    {
        if (tempTime != currentTime && OnTimeChange != null)
        {
            tempTime = currentTime;
            OnTimeChange(currentTime);
        }
    }

    public void InvokeGameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver.Invoke();
        }
    }

    private void OnEnable()
    {
        CatInteraction.OnCatPet += UpdateCounterCat;
    }

    private void OnDisable()
    {
        CatInteraction.OnCatPet -= UpdateCounterCat;
    }

    private void UpdateCounterCat()
    {
        if (!PlayerPrefs.HasKey("TimesCatPet"))
        {
            PlayerPrefs.SetInt("TimesCatPet", 1);
        }
        else
        {
            int tempValue = PlayerPrefs.GetInt("TimesCatPet");
            PlayerPrefs.SetInt("TimesCatPet", tempValue + 1);
        }
    }
}
