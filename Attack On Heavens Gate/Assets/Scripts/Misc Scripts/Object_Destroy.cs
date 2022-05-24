using UnityEngine;

public class Object_Destroy : MonoBehaviour
{
    public float timeTilDestroy, min, max;
    public bool destroyImmediately, destroyByTime, randomTime;

    void Start()
    {
        SetDestroy();
    }

    void RandomValue()
    {
        timeTilDestroy = Random.Range(min, max);
    }
    private void OnEnable()
    {
        SetDestroy();
    }

    private void OnDisable()
    {
        SetDestroy();
    }

    void SetDestroy()
    {
        if (destroyImmediately)
        {
            Destroy(gameObject, timeTilDestroy);
        }
        else if (destroyByTime)
        {
            if (randomTime)
                RandomValue();

            Destroy(gameObject, timeTilDestroy);
        }
    }

    public void Destroy()
    {
        Debug.Log("Destroying " + gameObject.name);
        Destroy(gameObject);
    }
}
