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


    public GameObject player;

    [SerializeField] public float maxTimeLevel;
    private float currentTime;
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
            DontDestroyOnLoad(gameObject);
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
                Debug.Log("alo");
            }
        }

        CheckTimerValueChange();
    }

    private void CheckTimerValueChange()
    {
        if(tempTime != currentTime && OnTimeChange != null){
            tempTime = currentTime;
            OnTimeChange(currentTime);
        }
    }
}
