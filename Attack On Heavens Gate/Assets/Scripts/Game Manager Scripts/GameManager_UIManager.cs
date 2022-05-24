using TMPro;
using UnityEngine;

public class GameManager_UIManager : MonoBehaviour
{
    #region Singleton
    private static GameManager_UIManager _instance;

    public static GameManager_UIManager Instance { get { return _instance; } }


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

    public GameObject roundTextGO;
    public TMP_Text scoreText;
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
