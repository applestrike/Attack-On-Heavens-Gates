using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Teleport : MonoBehaviour
{
    public Transform teleportLocation;

    private void Start()
    {
        //   teleportLocation = GetClosestEnemy(GameManager_TeleportHandler.Instance.teleportLocations, gameObject.transform);
//teleportLocation = PickRandomLocation(GameManager_TeleportHandler.Instance.teleportLocations, gameObject.transform);
    }

    public void TeleportObject(GameObject objectToTeleport, Transform teleportLocation)
    {
      //  GameManager_TeleportHandler.Instance.TeleportObject(objectToTeleport, teleportLocation);
    }

    Transform GetClosestEnemy(List<Transform> teleportLocations, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in teleportLocations)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                if (potentialTarget.transform.position == gameObject.transform.position)
                {

                }
                else
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }
        return bestTarget;
    }

    Transform PickRandomLocation(List<Transform> teleportLocations, Transform fromThis)
    {
        Transform randomLocation = default;

        while (randomLocation == default && randomLocation != gameObject.transform)
        {
            randomLocation = teleportLocations[Random.Range(0, teleportLocations.Count)];
        }

        return randomLocation;
    }
}
