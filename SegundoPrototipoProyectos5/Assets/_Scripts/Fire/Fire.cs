using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Only edit this:")]
    [SerializeField] private float regenTime = 2.5f;
    [SerializeField] private float regenRate = 5;
    [SerializeField] private ParticleSystem fireParticleSystem;
    [Header("Don't edit this:")]
    public float currentIntensity;
    public float maxEmissionRate;
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
            Debug.Log("estoy regenerandome");
        }
    }
}
