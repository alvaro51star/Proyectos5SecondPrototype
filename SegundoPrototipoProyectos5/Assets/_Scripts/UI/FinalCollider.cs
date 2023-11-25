using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCollider : MonoBehaviour
{
    [SerializeField] private UIManager uImanager;

    ///<summary> Cuando el player entra en el trigger se activa el menu de confirmacion para irse del nivel </summary>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            uImanager.ActivateUIGameObjects(uImanager.confirmEndLevel, true);
            uImanager.IsInGame(false);
        }
    }
}
