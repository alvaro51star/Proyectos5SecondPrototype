using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    /// <summary>Variable que sirve para desbloquear los botones hasta esa posicion del array</summary>
    [SerializeField] private int levelUnlocker = 0;

    private void Start()
    {
        UpdateLevelProgress(levelUnlocker);
    }

    public void UpdateLevelProgress(int level)
    {
        if (level >= PlayerPrefs.GetInt("LevelProgress"))
        {
            PlayerPrefs.SetInt("LevelProgress", level);
            PlayerPrefs.Save();
        }
    }
}
