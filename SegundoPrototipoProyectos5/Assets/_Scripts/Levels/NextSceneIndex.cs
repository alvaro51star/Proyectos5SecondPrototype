using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneIndex : MonoBehaviour
{
    public int nextSceneLoad;
    void Start()
    {
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
}
