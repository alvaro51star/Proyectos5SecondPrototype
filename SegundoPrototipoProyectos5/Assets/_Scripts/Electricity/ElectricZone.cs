using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

public class ElectricZone : MonoBehaviour
{
    private bool active;
    private bool canRecieveDamage = true;
    [SerializeField] private float timeBetweenDamageTicks = 0.5f;
    [SerializeField] private float damage = 20;

    [SerializeField] private List<ParticleSystem> particleSystems;

    #region EnableDisable
    private void OnEnable()
    {
        ElectricityManager.OnElectricityChange += ChangeState;
    }

    private void OnDisable()
    {
        ElectricityManager.OnElectricityChange -= ChangeState;
    }
    #endregion
   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canRecieveDamage && active)
        {
            other.GetComponent<LifeManager>().Damage(damage);
            canRecieveDamage = false;
            StartCoroutine(SetCanRecieveDamage());
        }
    }

    private IEnumerator SetCanRecieveDamage()
    {
        yield return new WaitForSeconds(timeBetweenDamageTicks);
        canRecieveDamage = true;
    }

    private void ChangeState(bool electrityStatus)
    {
        active = electrityStatus;
        SwitchFeedback(electrityStatus);
    }

// TODO: Add feedback
    private void SwitchFeedback(bool electrityStatus)
    {
        if (electrityStatus)
        {
            foreach (var particleSystem in particleSystems)
            {                
                particleSystem.Play();
            }            
        }
        else
        {
            foreach (var particleSystem in particleSystems)
            {                
                particleSystem.Stop();                
            }            
        }
    }
}
