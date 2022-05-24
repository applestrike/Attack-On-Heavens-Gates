using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public Vector2 direction;
    public float checkRate, nextCheck, movementSpeed, moveLength;
    public bool moveFowards, moveUpDown, continueCoroutine;

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            moveUpDown = !moveUpDown;
        }
        if (moveUpDown)
        {
            StartCoroutine(CallMoveUpAndDown());
        }
        if (moveFowards)
        {
            direction = new Vector2(-1, 0);
        }

        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private IEnumerator CallMoveUpAndDown()
    {
        direction = new Vector2(0, 1);
        yield return new WaitForSeconds(moveLength);
        direction = new Vector2(0, -1);
        yield return new WaitForSeconds(moveLength);
    }

}
