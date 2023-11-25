using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLifeManager : MonoBehaviour
{    
    [SerializeField] private Fire fire;
    [SerializeField] private CalculatePutOutFires calculatePutOutFires;
    [SerializeField] private AudioSource audioSource;

    [HideInInspector] public float maxLife = 100;
    [HideInInspector] public float currentLife;
    private float m_maxEmissionRate;

    private void Start()
    {
        currentLife = maxLife;
        m_maxEmissionRate = fire.maxEmissionRate;
    }

    public void Damage(float damage)
    {
        currentLife -= damage;
        //SoundManager.instance.ReproduceSound(AudioClipsNames.FireWaterDamage, audioSource);

        float lessParticles = (m_maxEmissionRate * currentLife) / maxLife;
        fire.DecreaseParticles(lessParticles);

        if (currentLife <= 0)
        {
            fire.Death();
            calculatePutOutFires.FirePutOut();
            //SoundManager.instance.ReproduceSound(AudioClipsNames.FireDeath, audioSource);
        }
    }
}
