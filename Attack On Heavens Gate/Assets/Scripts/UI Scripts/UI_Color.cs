using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Color : MonoBehaviour
{
    public TMP_Text TMPText;
    public float duration, delayTimerIntro, delayTimerOuter, totalTime;
    public Color32 startColor, endColor;
    public bool alphaBackToZero;

    private void Start()
    {
        TMPText = GetComponent<TMP_Text>();
        totalTime = delayTimerIntro + delayTimerOuter;
    }

    public void CallStartToFullColor()
    {
        StartCoroutine(FadeToFullColor());
    }

    protected IEnumerator FadeToFullColor()
    {
        Debug.Log("FadeToFullColor");
        yield return new WaitForSeconds(delayTimerIntro);
        float t = 0;

        TMPText.color = startColor;

        while (t < 1)
        {
            TMPText.color = Color32.Lerp(startColor, endColor, t);
            t += Time.deltaTime / duration;
            yield return null;
        }

        if (alphaBackToZero)
        {
            StartCoroutine(FadeToZeroColor());
        }
    }

    protected IEnumerator FadeToZeroColor()
    {
        Debug.Log("FadeToZeroColor");
        yield return new WaitForSeconds(delayTimerOuter);

        float t = 0;

        TMPText.color = startColor;

        while (t < 1)
        {
            TMPText.color = Color32.Lerp(endColor, startColor, t);
            t += Time.deltaTime / duration;
            yield return null;
        }

        if(gameObject.name == "Splash Screen - Text")
        {
            gameObject.SetActive(false);
        }
    }
}
