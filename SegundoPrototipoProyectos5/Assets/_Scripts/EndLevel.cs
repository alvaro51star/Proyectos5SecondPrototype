using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    UIManager uiManager;
    public void Yes()
    {
        FinalScore();
    }

    private void FinalScore()
    {
        uiManager.FinalScore();
    }
}
