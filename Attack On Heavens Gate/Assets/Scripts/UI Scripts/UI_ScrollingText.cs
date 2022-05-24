using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScrollingText : MonoBehaviour
{
    public float speed, fadeDirection, fadeTime, destroyObjectTimer, timeElapsed;
    public Vector3 direction;
    public AnimationCurve curveXLeft, curveYLeft;
    public Text text;
    public bool isCurved, started;
    public Vector3 startPosition, offSet;
    int random;
    bool justOnce;

    private void Start()
    {
        StartCoroutine(FadeTo(fadeDirection, fadeTime));
    }

    private void Update()
    {
        if (isCurved)
        {
            ChooseRandom();
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }

    public void SetText(string _text, Color _colorText)
    {
        text.text = _text;
        text.color = _colorText;
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        Color tempColor = text.color;
        float alpha = text.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(alpha, aValue, t));
            text.color = newColor;
            yield return null;
        }

        gameObject.SetActive(false);
        Destroy(gameObject, destroyObjectTimer);
    }

    void CurvedOne()
    {
        if (!started)
        {
            started = true;
            timeElapsed = 0;
            startPosition = transform.position;
        }
        else
        {
            timeElapsed += Time.deltaTime;
            direction = new Vector3(-curveXLeft.Evaluate(timeElapsed), -curveYLeft.Evaluate(timeElapsed), 0) + offSet;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void CurvedTwo()
    {
        if (!started)
        {
            started = true;
            timeElapsed = 0;
            startPosition = transform.position;
        }
        else
        {
            timeElapsed += Time.deltaTime;
            direction = new Vector3(-curveXLeft.Evaluate(timeElapsed), curveYLeft.Evaluate(timeElapsed), 0) + offSet;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void CurvedThree()
    {
        if (!started)
        {
            started = true;
            timeElapsed = 0;
            startPosition = transform.position;
        }
        else
        {
            timeElapsed += Time.deltaTime;
            direction = new Vector3(curveXLeft.Evaluate(timeElapsed), curveYLeft.Evaluate(timeElapsed), 0) + offSet;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void CurvedFour()
    {
        if (!started)
        {
            started = true;
            timeElapsed = 0;
            startPosition = transform.position;
        }
        else
        {
            timeElapsed += Time.deltaTime;
            direction = new Vector3(curveXLeft.Evaluate(timeElapsed), -curveYLeft.Evaluate(timeElapsed), 0) + offSet;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void ChooseRandom()
    {
        if (!justOnce)
        {
            justOnce = true;
            random = Random.Range(0, 4);
        }
        else
        {
            if (random == 0)
            {
                CurvedOne();
            }
            else if (random == 1)
            {
                CurvedTwo();
            }
            else if (random == 2)
            {
                CurvedThree();
            }
            else if (random == 3)
            {
                CurvedFour();
            }
        }
    }
}
