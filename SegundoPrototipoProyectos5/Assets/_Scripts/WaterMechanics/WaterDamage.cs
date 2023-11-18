using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private float maxLife;
    private float life;
    [SerializeField]private Fire fire;
    private float maxEmissionRate;

    private void Start()
    {
        life = maxLife;
        maxEmissionRate = fire.maxEmissionRate;
    }

    private void Update()
    {
        if (life <= 0) 
        {
            fire.Death();
        }
    }

    public void Damage(float damage)
    {
        life -= damage;

        float lessParticles = (maxEmissionRate * life) / maxLife;
        fire.DecreaseParticles(lessParticles);
    }
}
