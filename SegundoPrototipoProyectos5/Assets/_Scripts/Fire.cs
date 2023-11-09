using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float currentIntensity;
    [SerializeField] private float regenTime = 2.5f;
    [SerializeField] private float regenRate = 5;

    [SerializeField] private ParticleSystem fireParticleSystem;
    public float maxEmissionRate;
    private float timeLastWatered;

    private void Awake()
    {
        maxEmissionRate = fireParticleSystem.emission.rateOverTime.constant;
        currentIntensity = maxEmissionRate;
        timeLastWatered = regenTime;
    }

    private void Update()
    {
        Regeneration();
        //Debug.Log(fireParticleSystem.emission.rateOverTime.constant);
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
        timeLastWatered = regenTime;

        currentIntensity  = removerOfIntensity;
        ChangeIntensity();        
    }
    private void Regeneration()
    {
        timeLastWatered -= Time.deltaTime;

        if (currentIntensity < maxEmissionRate && timeLastWatered <= 0)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
            Debug.Log("estoy regenerandome");
        }
    }
}
