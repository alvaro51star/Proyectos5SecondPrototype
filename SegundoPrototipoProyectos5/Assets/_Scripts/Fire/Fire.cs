using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float regenTime = 2.5f;
    [SerializeField] private float regenRate = 5;
    [SerializeField] private ParticleSystem fireParticleSystem;
    [SerializeField, Range(0,1)] private float minParticleSizeMultiplier;
    [SerializeField, Range(0, 1)] private float maxParticleSizeMultiplier;

    public bool canChangeParticleSize;
    

    [HideInInspector] public float currentIntensity;
    [HideInInspector] public float maxEmissionRate;
    
    private float m_timeLastWatered;

    private void Awake()
    {
        maxEmissionRate = fireParticleSystem.emission.rateOverTime.constant;
        currentIntensity = maxEmissionRate;
        m_timeLastWatered = regenTime;
    }

    private void Update()
    {
        Regeneration();
    }

    public void Death()
    {
        if(currentIntensity <=0)
        {
            fireParticleSystem.Stop();
            Destroy(gameObject);
        }
    }
   
    private void ChangeIntensity()
    {
        currentIntensity = Mathf.Clamp(currentIntensity, 0f, maxEmissionRate);
        var emission = fireParticleSystem.emission;
        emission.rateOverTime = currentIntensity;
        ChangeParticleSize();
    }

    public void DecreaseParticles(float removerOfIntensity)
    {
        m_timeLastWatered = regenTime;

        currentIntensity  = removerOfIntensity;
        ChangeIntensity();        
    }
    private void Regeneration()
    {
        m_timeLastWatered -= Time.deltaTime;

        if (currentIntensity < maxEmissionRate && m_timeLastWatered <= 0)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();            
        }
    }
    private void ChangeParticleSize()
    {//dependiendo del currentIntensity, y por ende el emission.rateOverTime tendra una curva con valores mas o menos bajos
        var particleSize = fireParticleSystem.sizeOverLifetime;
        particleSize.enabled = true;


        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0, 0.1f);
        curve.AddKey(1.25f, 1.0f);

        if(canChangeParticleSize)
        {
            if (currentIntensity <= maxEmissionRate * 0.5f)
                particleSize.size = new ParticleSystem.MinMaxCurve(minParticleSizeMultiplier, curve);
            else
                particleSize.size = new ParticleSystem.MinMaxCurve(maxParticleSizeMultiplier, curve);
        }

    }
}
