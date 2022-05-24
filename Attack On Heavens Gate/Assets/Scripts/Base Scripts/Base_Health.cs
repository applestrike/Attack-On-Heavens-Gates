using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Health : MonoBehaviour
{
    Base_Death base_Death;
    Base_FlashOnHit base_FlashOnHit;
    Base_UI base_UI;

    public int currentHealth, maxHealth;

    private void Awake()
    {
        base_UI = GetComponent<Base_UI>();
        base_Death = GetComponent<Base_Death>();
        base_FlashOnHit = GetComponent<Base_FlashOnHit>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void HealHealth(int change)
    {
        if (currentHealth >= 0 && currentHealth < maxHealth)
        {
            currentHealth += change;

            if (this != null)
                base_UI.UpdateHealthBar();

            Debug.Log("Healing: " + gameObject + " " + currentHealth);
        }
    }

    public virtual void TakeDamage(int change)
    {
        if (currentHealth >= 0)
        {
            base_FlashOnHit.CallFlashOnHit();

            currentHealth -= change;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                CheckForDeath();
            }

            base_UI.UpdateHealthBar();
        }
    }

    public virtual void CheckForDeath()
    {
        if (currentHealth <= 0)
        {
            base_Death.OnDeath();
        }
    }
}
