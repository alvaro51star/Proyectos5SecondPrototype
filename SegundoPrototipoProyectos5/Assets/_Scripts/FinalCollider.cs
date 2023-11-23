using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCollider : MonoBehaviour
{
    [SerializeField] private UIManager uImanager;
    private void OnTriggerEnter(Collider other)
    {
        //Llamar al UIController para que active men� de confirmaci�n para irse
        Debug.Log("entra en trigger");
        uImanager.EndGame();
    }
}
