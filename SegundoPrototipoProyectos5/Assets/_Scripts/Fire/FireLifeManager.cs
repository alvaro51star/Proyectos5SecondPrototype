using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLifeManager : MonoBehaviour
{    
    [SerializeField] private Fire fire;
    [SerializeField] private CalculatePutOutFires calculatePutOutFires;

    [HideInInspector] public float maxLife = 100;
    [HideInInspector] public float currentLife;
    private float m_maxEmissionRate;

    private AudioSource m_audioSource;

    private void Start()
    {
        currentLife = maxLife;
        m_maxEmissionRate = fire.maxEmissionRate;
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Damage(float damage)
    {
        currentLife -= damage;
        if (!m_audioSource.isPlaying)
        {
            SoundManager.instance.ReproduceSound(AudioClipsNames.FireDying_1, m_audioSource);
        }

        float lessParticles = (m_maxEmissionRate * currentLife) / maxLife;
        fire.DecreaseParticles(lessParticles);

        if (currentLife <= 0)
        {
            SoundManager.instance.ReproduceSound(AudioClipsNames.FireDying_2, m_audioSource);

            calculatePutOutFires.FirePutOut();
            fire.Death();
        }
    }
}
