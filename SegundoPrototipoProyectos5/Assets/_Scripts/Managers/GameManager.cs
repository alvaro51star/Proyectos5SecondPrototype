using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public GameObject player;

    [SerializeField] private float maxTimeLevel;
    private float currentTime;
    private bool isDone = false;

    

    private void Start()
    {
        currentTime = maxTimeLevel;
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

    private void Update() {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0 && !isDone)
        {
            isDone = true;
            if (OnGameOver != null)
            {
                OnGameOver();
                Debug.Log("alo");
            }
        }
    }


}
