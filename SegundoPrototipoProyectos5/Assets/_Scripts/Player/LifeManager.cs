using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private float life = 100f;

    private void Update()
    {
        Debug.Log(life);
    }

    public void Damage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            //!Se activa el game over
        }
    }
}
