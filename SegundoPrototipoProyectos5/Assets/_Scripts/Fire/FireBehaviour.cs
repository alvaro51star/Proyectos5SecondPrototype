using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireParticleSystem;
    [SerializeField] private float damage;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<LifeManager>().Damage(damage);
        }
    }
}
