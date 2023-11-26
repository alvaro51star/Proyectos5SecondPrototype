using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Icons : MonoBehaviour
{
    public TMP_Text numberFiresLeft;
    public TMP_Text numberVictimsLeft;
    public TMP_Text maxNumberFires;
    public TMP_Text maxNumberVictims;

    public void ChangeNumber(float number, TMP_Text textForTheNumber)
    {       
        textForTheNumber.text = number.ToString();
    }

    public void SetMaxNumber(float maxNumber, TMP_Text textForMaxNumber)
    {
        textForMaxNumber.text = maxNumber.ToString();
    }
}
