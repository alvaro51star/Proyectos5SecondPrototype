using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePutOutFires : MonoBehaviour
{
    [SerializeField] private GameObject[] fires;
    [SerializeField] private Icons icons;
    [HideInInspector] public int totalNumberOfFires;
    [HideInInspector] public int putOutFires = 0;
    private void Start()
    {
        totalNumberOfFires = fires.Length;
        icons.SetMaxNumber(totalNumberOfFires, icons.maxNumberFires);
    }

    public void FirePutOut()
    {
        putOutFires += 1;
        putOutFires = Mathf.Clamp(putOutFires, 0, totalNumberOfFires);
        icons.ChangeNumber(putOutFires, icons.numberFiresLeft);

        if (putOutFires >= totalNumberOfFires)
        {
            //SoundManager.instance.ReproduceSound();
        }
    }
}
