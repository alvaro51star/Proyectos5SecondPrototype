using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConductiveZone : MonoBehaviour
{
    public bool waterReached = false;

    [SerializeField] private List<ParticleSystem> disabledParticleSystems;
    [SerializeField] private ParticleSystem enabledParticleSystem;
    [SerializeField] private ElectricityManager electricityManager;

    private void OnEnable()
    {
        ElectricityManager.OnElectricityChange += SetParticles;
    }

    private void OnDisable()
    {
        ElectricityManager.OnElectricityChange -= SetParticles;
    }

    private void Update() {
        if(waterReached && electricityManager.active){
            if (!enabledParticleSystem.isPlaying)
            {
                enabledParticleSystem.Play();
                foreach (var particleSystem in disabledParticleSystems)
                {
                    particleSystem.Stop();
                }
            }
        }
    }

    private void SetParticles(bool electricityStatus)
    {
        if (electricityStatus)
        {
            if (waterReached)
            {
                enabledParticleSystem.Play();
                SoundManager.instance.ReproduceSound(AudioClipsNames.ElectricWire);
            }
            else
            {
                foreach (var particleSystem in disabledParticleSystems)
                {
                    particleSystem.Play();
                }
            }

        }
        else
        {
            foreach (var particleSystem in disabledParticleSystems)
            {
                particleSystem.Stop();
            }
            enabledParticleSystem.Stop();
        }
    }
}
