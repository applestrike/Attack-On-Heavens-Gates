using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    Enemy_ProcessStats enemy_ProcessStats;

    private Base_Information _detectedPlayer;

    public bool EnemyInRange => _detectedPlayer != null;
    public GameObject inRangeGO, triggerGO;

    private void Awake()
    {
        enemy_ProcessStats = GetComponent<Enemy_ProcessStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Base_Information otherInformation = collision.GetComponentInParent<Base_Information>();

        if (otherInformation != null)
        {
            if (otherInformation._tag == "Player" && inRangeGO.GetComponent<Collider2D>().IsTouching(collision))
            {
                _detectedPlayer = otherInformation;
            }

            if (otherInformation._tag == "Player Projectile" && triggerGO.GetComponent<Collider2D>().IsTouching(collision))
            {
                enemy_ProcessStats.ProcessDamage(otherInformation.damage);
                otherInformation.GetComponent<Base_Death>().OnDeath();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_detectedPlayer != null)
        {
            if (_detectedPlayer._tag == "Player")
            {
                Debug.Log("Player Out Of Range");
                StartCoroutine(ClearDetectedPlayerAfterDelay());
            }
        }
    }

    private IEnumerator ClearDetectedPlayerAfterDelay()
    {
        Debug.Log("ClearDetectedPlayerAfterDelay");
        yield return new WaitForSeconds(1f);
        _detectedPlayer = null;
    }

    public Vector2 GetNearestPlayerPosition()
    {
        return _detectedPlayer?.transform.position ?? Vector2.zero;
    }

    public bool CheckForTriggerGO(Collider2D collision)
    {
        Debug.Log(triggerGO.GetComponent<Collider2D>().IsTouching(collision));
        return triggerGO.GetComponent<Collider2D>().IsTouching(collision);
    }
}
