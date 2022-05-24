using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_ParticleEffect : MonoBehaviour
{
    public GameObject particleEffect, greenParticleEffect, yellowParticleEffect;

    public virtual void SpawnParticleEffect()
    {
        GameObject newParticleEffect = Instantiate(particleEffect, gameObject.transform);
        newParticleEffect.transform.SetParent(GameManager_References.Instance.particleSpacer.transform);
    }

    public virtual void SpawnGreenParticleEffect()
    {
        GameObject newParticleEffect = Instantiate(greenParticleEffect, gameObject.transform);
        newParticleEffect.transform.SetParent(GameManager_References.Instance.particleSpacer.transform);
    }

    public virtual void SpawnYellowParticleEffect()
    {
        GameObject newParticleEffect = Instantiate(yellowParticleEffect, gameObject.transform);
        newParticleEffect.transform.SetParent(GameManager_References.Instance.particleSpacer.transform);
    }

}
