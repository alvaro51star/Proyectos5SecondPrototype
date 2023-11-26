using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    [Header ("SOLO FUNCIONA EN EL GAMEOBJECT DEL SIST DE PARTICULAS")]
    [SerializeField] private Fire fire;
    [Header("Segun la intensidad del fuego hara +o- damage")]
    [SerializeField] private float maxDamage;
    [SerializeField] private float minDamage;
    private float m_damage;
    private float m_maxEmissionRate;

    private void Start()
    {
        m_maxEmissionRate = fire.maxEmissionRate;
    }
    
    private void DamageControl()
    {
        //segun la intensidad del fuego hara mas o menos daño MEJORAR ESTO SEGUN FEEDBACK
        float intensity = fire.currentIntensity;

        if (intensity < (m_maxEmissionRate * 0.5f))
        {
            m_damage = minDamage;
        }

        else
        {
            m_damage = maxDamage;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        DamageControl();
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<LifeManager>().Damage(m_damage);
        }
    }
}
