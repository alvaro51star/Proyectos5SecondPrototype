using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCollider : MonoBehaviour
{
    [SerializeField] private UIManager uImanager;
    private void OnTriggerEnter(Collider other)
    {
        //Llamar al UIController para que active menú de confirmación para irse
        uImanager.ActivateUIGameObjects(uImanager.endPanel, true);
    }
}
