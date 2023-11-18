using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float regenTime = 2.5f;
    [SerializeField] private float regenRate = 5;
    [SerializeField] private ParticleSystem fireParticleSystem;
    [SerializeField] private FireLifeManager fireLifeManager;
    [Header("CUANTO MAS GRANDE MAS PARTICULAS HAY QUE PONER")]
    public float maxEmissionRate;
    [SerializeField, Range(0,1)] private float minParticleSizeMultiplier;
    [SerializeField, Range(0, 1)] private float maxParticleSizeMultiplier;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;
    [SerializeField] private BoxCollider boxCollider;

    [HideInInspector] public float currentIntensity;
    
    private float m_timeLastWatered;
    private Vector3 m_InitialParticleSystemShapeScale;

    private void Awake()
    {
        var fireEmissionRateOverTime = fireParticleSystem.emission.rateOverTime;
        fireEmissionRateOverTime.constantMax = maxEmissionRate;

        currentIntensity = maxEmissionRate;
        m_timeLastWatered = regenTime;
        m_InitialParticleSystemShapeScale = fireParticleSystem.shape.scale * maxScale;
        ChangeSize();
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
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void DecreaseParticles(float removerOfIntensity)
    {
        m_timeLastWatered = regenTime;

        currentIntensity = removerOfIntensity;
        ChangeIntensity();
        ChangeParticleSize();
        ChangeSize();
    }

    private void ChangeIntensity()
    {
        currentIntensity = Mathf.Clamp(currentIntensity, 0f, maxEmissionRate);
        var emission = fireParticleSystem.emission;
        emission.rateOverTime = currentIntensity;
    }

    private void Regeneration()
    {
        m_timeLastWatered -= Time.deltaTime;

        if (currentIntensity < maxEmissionRate && m_timeLastWatered <= 0)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
            ChangeParticleSize();
            ChangeSize();
        }
        if(currentIntensity == maxEmissionRate)
            fireLifeManager.currentLife = fireLifeManager.maxLife;
    }
    private void ChangeParticleSize()
    {
        float particleSizeMultiplier = ((maxParticleSizeMultiplier * currentIntensity) / maxEmissionRate);
        particleSizeMultiplier = Mathf.Clamp(particleSizeMultiplier, minParticleSizeMultiplier, maxParticleSizeMultiplier);
        
        var particleSize = fireParticleSystem.sizeOverLifetime;
        particleSize.enabled = true;

        if (currentIntensity <= maxEmissionRate * 0.9f)
            particleSize.sizeMultiplier = particleSizeMultiplier;

        else
            particleSize.sizeMultiplier = maxParticleSizeMultiplier;
    }

    private void ChangeSize()
    {
        var particleSystemShape = fireParticleSystem.shape;
        particleSystemShape.enabled = true;

        if (currentIntensity <= maxEmissionRate * 0.9f)
        {
            float sizeMultiplier = ((currentIntensity * maxScale) / maxEmissionRate);
            Vector3 newScale = Vector3.one * sizeMultiplier;
            particleSystemShape.scale = newScale;

            ChangeColliderSize(sizeMultiplier);
        }
        else
        {
            particleSystemShape.scale = m_InitialParticleSystemShapeScale;
            ChangeColliderSize(maxScale);
        }
    }

    private void ChangeColliderSize(float scaleMultiplier)
    {
        boxCollider.size = Vector3.one * scaleMultiplier;

        boxCollider.center = new Vector3 (0, scaleMultiplier* 0.5f,0);
    }
}
