using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ScoreManager : MonoBehaviour
{
    #region Singleton
    private static GameManager_ScoreManager _instance;

    public static GameManager_ScoreManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public int currentScore, newScore,pointsPerSec;
    bool justOnce;

    public void OnPointsScored(int newPoints)
    {
        newScore += newPoints;
    }

    private void Update()
    {
        LerpScore();
    }

    void LerpScore()
    {
        if (currentScore < newScore)
        {
            currentScore += pointsPerSec;
            GameManager_UIManager.Instance.UpdateScoreText(currentScore);
        }
    }

    public void CallAddUpScore()
    {
        if (!justOnce)
        {
            justOnce = true;
            StartCoroutine(AddUpScore());
        }
    }

    IEnumerator AddUpScore()
    {
        yield return new WaitForSeconds(1f);
    }
}
