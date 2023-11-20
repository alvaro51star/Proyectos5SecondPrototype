using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private float maxLife = 100f;
    [SerializeField] private float regenTime = 2.5f;
    [SerializeField] private float regenRate = 5;
    [SerializeField] private AudioSource audioSource;
    private float m_timeLastDamaged;
    private float m_currentLife;

    private void Start()
    {
        m_timeLastDamaged = regenTime;
        m_currentLife = maxLife;
    }
    private void Update()
    {
        Regeneration();
        Debug.Log(m_currentLife);
    }
    public void Damage(float damage)
    {
        m_currentLife -= damage;
        //SoundManager.instance.ReproduceSound(AudioClipsNames.Auch, audioSource);

        m_timeLastDamaged = regenTime;
        

        if (m_currentLife <= 0)
        {
            //!Se activa el game over
            GameManager.instance.InvokeGameOver();
        }
    }

    private void Regeneration()
    {
        m_timeLastDamaged -= Time.deltaTime;

        if(m_currentLife < maxLife && m_timeLastDamaged <= 0)
            m_currentLife += regenRate * Time.deltaTime;

        m_currentLife = Mathf.Clamp(m_currentLife, 0, maxLife);
    }
}
