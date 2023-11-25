using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    /// <summary>Lista de los botones de los niveles</summary>
    [SerializeField] private List<Button> buttons;
    /// <summary>Variable que sirve para desbloquear los botones hasta esa posicion del array</summary>
    [SerializeField] private int levelUnlocker = 0; 

    private void Start()
    {
        PlayerPrefs.SetInt("LevelProgress", 0);
        PlayerPrefs.Save();
        EnableButtons();
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
        PlayerPrefs.Save();
    }

    public void EnableButtons()
    {
        if (buttons != null && PlayerPrefs.HasKey("LevelProgress"))
        {
            for (int i = 0; i <= PlayerPrefs.GetInt("LevelProgress"); i++)
            {
                buttons[i].interactable = true;
            }
        }
    }
}
