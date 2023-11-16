using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private float maxLife;
    private float life;
    private Fire fire;
    private float maxEmissionRate;

    private void Start()
    {
        fire = GetComponent<Fire>();
        life = maxLife;
        maxEmissionRate = fire.maxEmissionRate;
    }

    private void Update()
    {
        //Debug.Log("life = " + life);
        if (life <= 0) 
        {
            fire.Death();
            Debug.Log("fuego muerto");
        }
    }

    public void Damage(float damage)
    {
        life -= damage;

        float lessParticles = (maxEmissionRate * life) / maxLife;
        fire.DecreaseParticles(lessParticles);
    }
}
