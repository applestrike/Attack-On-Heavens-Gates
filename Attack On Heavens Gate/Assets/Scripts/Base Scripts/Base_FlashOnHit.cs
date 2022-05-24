using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_FlashOnHit : MonoBehaviour
{
    public SpriteRenderer mySR;
    bool justOnce;
    public float timer = default;
    float nextCheck;

    public virtual void CallFlashOnHit()
    {
        if (!justOnce)
        {
            StartCoroutine(ChangeColor());
        }
    }

    public virtual IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 135);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 135);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 135);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 135);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 135);
        yield return new WaitForSeconds(timer);
        mySR.color = new Color(255, 255, 255, 135);
        ChangeBackToNormal();
    }

    public virtual void ChangeBackToNormal()
    {
        mySR.color = new Color(255, 255, 255, 255);
        justOnce = false;
    }
}
