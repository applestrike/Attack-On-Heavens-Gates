using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene_Manager : MonoBehaviour
{
    #region Singleton
    private static Scene_Manager _instance;

    public static Scene_Manager Instance { get { return _instance; } }

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

    public string currentSceneName;
    public bool canLoadNextScene;

    public enum Scenes
    {
        Preload,
        SplashScreen,
        MainMenu,
        GamePlay
    }

    public Scenes currentScene;

    void OnEnable()
    {
        CheckCurrentLevelName();
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    public void CheckCurrentLevelName()
    {
        currentSceneName = SceneManager.GetActiveScene().name.ToString();
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnLevelFinishedLoading");

        CheckCurrentLevelName();
    }
    
    public void CallNextScene(float loadTimer, Scenes nextScene, float delayTimer, bool withLoadScreen)
    {
        StartCoroutine(NextSceneWithDelay(loadTimer, nextScene, delayTimer, withLoadScreen));   
    }

     IEnumerator NextSceneWithDelay(float loadTimer, Scenes nextScene, float delayTimer,bool withLoadScreen)
    {
        yield return new WaitForSeconds(loadTimer);
        NextScene(nextScene, delayTimer, withLoadScreen);
    }

    void NextScene(Scenes nextScene, float delayTimer, bool withLoadScreen)
    {
        Debug.Log("Next Scene");
        SceneLoader.Instance.CallLoadNextScene(nextScene.ToString(), delayTimer, withLoadScreen);
    }
}

