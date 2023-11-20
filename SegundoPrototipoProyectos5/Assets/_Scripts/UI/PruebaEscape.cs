using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaEscape : MonoBehaviour
{
    [SerializeField] UI_Manager2 m_uiManager2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_uiManager2.PauseMenu();
        }
    }
}
