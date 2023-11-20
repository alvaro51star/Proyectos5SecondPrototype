using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(SetPlayer());
    }

    private IEnumerator SetPlayer()
    {
        yield return new WaitForEndOfFrame();
        GameManager.instance.player = gameObject;
        Debug.Log("Player set");
    }
}
