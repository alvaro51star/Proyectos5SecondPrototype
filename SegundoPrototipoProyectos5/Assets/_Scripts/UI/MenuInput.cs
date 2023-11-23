using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    [SerializeField] UIMenus m_uiMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_uiMenu.PauseMenu();
        }
    }
}
