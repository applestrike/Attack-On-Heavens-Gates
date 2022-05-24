using UnityEngine;

public class GameManager_References : MonoBehaviour
{
    #region Singleton 
    private static GameManager_References _instance;

    public static GameManager_References Instance { get { return _instance; } }


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
    public GameObject environment;
    public GameObject particleSpacer, projectileParent, playerPrefab, respawnPosition, currentPlayer;
}
