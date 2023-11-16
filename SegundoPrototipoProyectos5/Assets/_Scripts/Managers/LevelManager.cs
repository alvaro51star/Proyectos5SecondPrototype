using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private List<Button> buttons;

    private void Start()
    {
        PlayerPrefs.SetInt("LevelProgress", 0);
        PlayerPrefs.Save();
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

    public void UpdateLevelProgress(int level)
    {
        PlayerPrefs.SetInt("LevelProgress", level);
    }

    public void EnableButtons()
    {
        if (buttons != null && PlayerPrefs.HasKey("LevelProgress"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("LevelProgress"); i++)
            {
                buttons[i].enabled = true;
            }
        }
    }

}
