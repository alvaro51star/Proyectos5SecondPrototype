using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.player = gameObject;
    }
}
