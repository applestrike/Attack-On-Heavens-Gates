using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_RespawnPosition : MonoBehaviour
{
    public void SetRespawnPoint()
    {
        Debug.Log("SetRespawnPoint");
        GameManager_References.Instance.respawnPosition = gameObject;
    }
}
