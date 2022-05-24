using UnityEngine;

public class GameManager_SaveLoad : MonoBehaviour
{
    #region Singleton 
    private static GameManager_SaveLoad _instance;

    public static GameManager_SaveLoad Instance { get { return _instance; } }


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

    public void Save()
    {

    }

    public void Load()
    {

    }
}
