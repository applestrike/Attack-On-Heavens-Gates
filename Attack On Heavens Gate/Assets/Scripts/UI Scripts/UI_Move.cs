using System.Collections;
using UnityEngine;

public class UI_Move : MonoBehaviour
{
    public float speed, duration;
    public Vector2 startPosition, endPosition;

    private void Start()
    {
        StartCoroutine(LerpFunction(endPosition));
    }

    IEnumerator LerpFunction(Vector2 endPosition)
    {
        float time = 0;
        startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = endPosition;
    }

}
