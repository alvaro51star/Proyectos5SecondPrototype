using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    /*private void Awake()
    {
        StartCoroutine(SetPlayer());
    }

    private IEnumerator SetPlayer()
    {
        yield return new WaitForEndOfFrame();
        GameManager.instance.player = gameObject;
        Debug.Log("Player set");
    }*/

    [SerializeField] private Transform bodyTransform;

    public bool HasBody()
    {
        if (bodyTransform.childCount <= 0)
        {
            return false;
        }
        return true;
    }
}
