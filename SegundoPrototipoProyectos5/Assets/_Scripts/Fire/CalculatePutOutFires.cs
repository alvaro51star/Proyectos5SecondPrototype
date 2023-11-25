using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePutOutFires : MonoBehaviour
{
    [SerializeField] private GameObject[] fires;
    [HideInInspector] public int totalNumberOfFires;
    [HideInInspector] public int putOutFires = 0;
    private void Start()
    {
        totalNumberOfFires = fires.Length;
    }

    public void FirePutOut()
    {
        putOutFires += 1;
        putOutFires = Mathf.Clamp(putOutFires, 0, totalNumberOfFires);
        Debug.Log("fires put out:  " + putOutFires + "/" + totalNumberOfFires);

        if (putOutFires >= totalNumberOfFires)
        {
            Debug.Log("Enhorabuena, has apagado todos los fuegos");
            //SoundManager.instance.ReproduceSound();
        }
    }
}
