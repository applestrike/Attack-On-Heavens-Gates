using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton 
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


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

    public static bool IsInputEnabled = true;

    public void OnGamePlay()
    {
        Debug.Log("OnGamePlay");
        GameManagerController.Instance.currentState = GameManagerController.GameStates.GamePlay;
        GameController.Instance.startGamePlay = true;
        UI_Manager.Instance.DisableGameOverMenu();
        UI_Manager.Instance.EnableGamePlayUI();
    }

    public void CallGameOver()
    {
        Debug.Log("Game Over");
        GameController.Instance.startGamePlay = false;
        UI_Manager.Instance.EnableGameOverMenu();
        GameManagerController.Instance.currentState = GameManagerController.GameStates.GameOver;
    }

    public void EnableEnvironment()
    {
        GameManager_References.Instance.environment.SetActive(true);
    }
}
