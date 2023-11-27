using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    void Update()
    {
        if (PlayerPrefs.HasKey("TimesCatPet"))
        {
            text.text = PlayerPrefs.GetInt("TimesCatPet").ToString();
        }
    }
}
