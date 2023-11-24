using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    [SerializeField] UIMenus uIMenu;
    [SerializeField] UIManager uIManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uIManager.dead == false)
            {
                if (uIMenu.isAMenuOrPanel == false)
                uIMenu.PauseMenu();
            }
        }
    }
}
