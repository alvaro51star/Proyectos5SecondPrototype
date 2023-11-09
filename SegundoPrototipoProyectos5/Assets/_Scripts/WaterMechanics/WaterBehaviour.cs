using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterParticleSystem;
    [SerializeField] private float damage = 10f;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            other.GetComponent<WaterDamage>().Damage(damage);
        }
    }
}
