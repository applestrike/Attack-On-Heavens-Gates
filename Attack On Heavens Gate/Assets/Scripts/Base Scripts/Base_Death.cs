using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Death : MonoBehaviour
{
    Base_ParticleEffect base_ParticleEffect;

    private void Awake()
    {
        base_ParticleEffect = GetComponent<Base_ParticleEffect>();
    }

    public virtual void OnDeath()
    {
        base_ParticleEffect.SpawnParticleEffect();
        Destroy(gameObject);
    }

    public virtual void OnDeath(float timer)
    {
        if (base_ParticleEffect != null)
            base_ParticleEffect.SpawnParticleEffect();
        Destroy(gameObject, timer);
    }
}
