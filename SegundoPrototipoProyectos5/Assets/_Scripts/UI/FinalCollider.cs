using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCollider : MonoBehaviour
{
    [SerializeField] private UIManager uImanager;
    [SerializeField] private CalculateSavedNPCs calculateSavedNPCs;

    ///<summary> Cuando el player entra en el trigger se activa el menu de confirmacion para irse del nivel </summary>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            uImanager.DesactivateAllUIGameObjects();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            uImanager.camera.GetComponent<CameraRotation>().enabled = false;


            if (calculateSavedNPCs.everyoneHasBeenSaved)
            {
                uImanager.ActivateUIGameObjects(uImanager.confirmEndLevel, true);
            }
            else
            {
                uImanager.ActivateUIGameObjects(uImanager.dontAllowToLeaveLevelPanel, true);
            }
        }
    }
}
