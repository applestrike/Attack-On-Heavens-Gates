using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Collision : MonoBehaviour
{
    Projectile_Information projectile_Information;
    Projectile_Death projectile_Death;

    private void Awake()
    {
        projectile_Information = GetComponentInParent<Projectile_Information>();
        projectile_Death = GetComponentInParent<Projectile_Death>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Base_Information base_Information = collision.GetComponentInParent<Base_Information>();

        if (base_Information != null)
        {
            if (base_Information._tag.Contains("Player"))
            {
                return;
            }

            if (base_Information._tag == "Enemy")
            {
                //if (collider2D.IsTouching(base_Information.GetComponent<Enemy_RangeDetection>().triggerGO.GetComponent<Collider2D>()))
                //    projectile_Death.OnDeath();
            }
        }
    }
}
