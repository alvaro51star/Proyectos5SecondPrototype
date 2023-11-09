using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private float life = 300f;
    [SerializeField] Fire Fire;
   
    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(float damage)
    {
        life -= damage;
    }
}
