using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lives : MonoBehaviour
{
    Player_Information player_Information;

    public float respawnTimer;

    bool justOnce;

    private void Awake()
    {
        player_Information = GetComponent<Player_Information>();
    }

    public void CheckLives()
    {
        if (player_Information.playerLifes > 0)
        {
            RespawnPlayer();
        }
    }

    void CallRespawnPlayer()
    {
        if (!justOnce)
        {
            justOnce = true;
            StartCoroutine(RespawnPlayer());
        }
    }

    private IEnumerator RespawnPlayer()
    {
        Debug.Log("Respawning Player");


        yield return new WaitForSeconds(respawnTimer);

        player_Information.playerLifes--;

        GameObject newPlayerObject = Instantiate(GameManager_References.Instance.playerPrefab,
            GameManager_References.Instance.respawnPosition.transform);
    }
}
