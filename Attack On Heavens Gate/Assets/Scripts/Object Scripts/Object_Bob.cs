using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bob : MonoBehaviour
{
    public Vector2 direction;
    public float checkRate, nextCheck, movementSpeed, moveLength;
    public bool moveUpDown;
    bool justOnce;

    private void Update()
    {
        BobObject();
    }

    void BobObject()
    {
        if (!justOnce)
        {
            justOnce = true;
            StartCoroutine(CallMoveUpAndDown());
        }
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private IEnumerator CallMoveUpAndDown()
    {
        direction = new Vector2(0, 1);
        yield return new WaitForSeconds(moveLength);
        direction = new Vector2(0, -1);
        yield return new WaitForSeconds(moveLength);
        justOnce = false;
    }
}
