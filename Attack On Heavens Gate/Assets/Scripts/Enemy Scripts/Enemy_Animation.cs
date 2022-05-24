using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    Vector2 newPos, oldPos;
    public Enemy enemy;
    public SpriteRenderer enemySR;

    public Vector2 facingDirection;

    private void Awake()
    {
        enemySR = GetComponentInChildren<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        TrackDirection();
    }

    void TrackDirection()
    {
        newPos = transform.position;
        Vector2 velocity = (newPos - oldPos);
        Vector2 direction = velocity.normalized;
        facingDirection = direction;

        if (facingDirection.x < -.1f)
        {
            enemySR.flipX = false;
        }
        else
        {
            enemySR.flipX = true;
        }

        oldPos = transform.position;
    }
}
