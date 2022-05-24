using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSecs : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        DestroyGameObject();
    }

    public virtual void DestroyGameObject()
    {
        Destroy(gameObject, timer);
    }
}
