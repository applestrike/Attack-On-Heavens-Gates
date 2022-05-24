using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_ProcessStats : MonoBehaviour
{
    Base_Health base_Health;

    private void Awake()
    {
        base_Health = GetComponent<Base_Health>();
    }

    public virtual void ProcessDamage(int value)
    {
        base_Health.TakeDamage(value);
    }

    public virtual void ProcessHealing(int value)
    {
        base_Health.HealHealth(value);
    }
}
