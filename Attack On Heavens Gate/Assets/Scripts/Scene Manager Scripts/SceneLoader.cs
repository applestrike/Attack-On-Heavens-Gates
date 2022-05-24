using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    #region Singleton
    private static SceneLoader _instance;

    public static SceneLoader Instance { get { return _instance; } }

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

    public GameObject loadingScreen;
    public CanvasGroup canvasGroup;
    public AsyncOperation loadingOperation;
    public Slider progressBar;
    public float progressValue;
    public Text percentLoaded;
    bool justOnce;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        UpdateProgressLoadingBar();
    }

    void UpdateProgressLoadingBar()
    {
        if (loadingScreen.activeSelf)
        {
            if (loadingOperation != null)
                progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            progressValue = progressBar.value;
            percentLoaded.text = "Loading... " + Mathf.Round(progressValue * 100) + "%";
        }
    }

    public void CallLoadNextScene(string nextScene, float delay, bool withLoadScreen)
    {
        Debug.Log("CallLoadNextScene " + justOnce);
        if (!justOnce && Scene_Manager.Instance.canLoadNextScene)
        {
            justOnce = true;
            StartCoroutine(LoadNextScene(nextScene, delay,withLoadScreen));
        }
    }

    IEnumerator LoadNextScene(string nextScene, float delay,bool withLoadScreen)
    {
        Debug.Log("CallLoadNextScene - Successful - " + nextScene);
        progressValue = 0;
        percentLoaded.text = "Loading... " + Mathf.Round(progressValue * 100) + "%";
        yield return new WaitForSeconds(delay);

        Scene_Manager.Instance.canLoadNextScene = false;

        if (withLoadScreen)
            loadingScreen.SetActive(true);

        yield return StartCoroutine(FadeLoadingScreen(1, 1));

        loadingOperation = SceneManager.LoadSceneAsync(nextScene);

        while (!loadingOperation.isDone)
        {
            UpdateProgressLoadingBar();
            yield return null;
        }

        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
        justOnce = false;
        Scene_Manager.Instance.canLoadNextScene = true;

        GameManagerController.Instance.UpdateCurrentState();
    }

    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}