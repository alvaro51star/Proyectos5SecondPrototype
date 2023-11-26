using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUnlocker : MonoBehaviour
{
    /// <summary>Lista de los botones de los niveles</summary>
    [SerializeField] private List<Button> buttons;

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
