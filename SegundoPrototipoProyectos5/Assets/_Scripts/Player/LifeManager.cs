using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class LifeManager : MonoBehaviour
{
    public delegate void ChangeLifeDelegate(float newVal, float newVal2);
    public static event ChangeLifeDelegate OnLifeChange;

    [SerializeField] private float maxLife = 100f;
    [SerializeField] private float regenTime = 2.5f;
    [SerializeField] private float regenRate = 5;
    private AudioSource m_audioSource;
    private float m_timeLastDamaged;
    private float m_currentLife;

    private bool isDone = false;

    private void Start()
    {
        m_timeLastDamaged = regenTime;
        m_currentLife = maxLife;
        m_audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Regeneration();
    }
    public void Damage(float damage)
    {
        m_currentLife -= damage;
        DamageSound(damage);

        if (OnLifeChange != null)
        {
            OnLifeChange(m_currentLife, maxLife);
        }

        m_timeLastDamaged = regenTime;

        if (m_currentLife <= 0 && !isDone)
        {
            GameManager.instance.InvokeGameOver();
            isDone = true;
        }
    }
    private void Regeneration()
    {
        m_timeLastDamaged -= Time.deltaTime;

        if (m_currentLife < maxLife && m_timeLastDamaged <= 0)
            m_currentLife += regenRate * Time.deltaTime;

        m_currentLife = Mathf.Clamp(m_currentLife, 0, maxLife);

        if (OnLifeChange != null)
        {
            OnLifeChange(m_currentLife, maxLife);
        }
    }

    private void DamageSound(float damage)
    {
        if (!m_audioSource.isPlaying)
        {
            if (damage < 5)
            {
                SoundManager.instance.ReproduceSound(AudioClipsNames.Grunt_1, m_audioSource);
            }
            else
            {
                int clip = Random.Range(0, 1);
                if (clip == 0)
                {
                    SoundManager.instance.ReproduceSound(AudioClipsNames.Grunt_2, m_audioSource);
                }
                else if (clip == 1)
                {
                    SoundManager.instance.ReproduceSound(AudioClipsNames.Grunt_4, m_audioSource);
                }
            }
        }           
    }   
}
