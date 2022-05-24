using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Move : MonoBehaviour
{
    public Vector2 direction;
    public float movementSpeed;

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
