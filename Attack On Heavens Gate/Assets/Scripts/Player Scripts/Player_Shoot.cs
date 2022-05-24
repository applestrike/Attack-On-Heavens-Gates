using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    Player_Controller player_Controller;
    Player_Animation player_Animation;
    public float checkRate, nextCheck;
    public Transform shootLeftPosition, shootRightPosition;
    public GameObject projectileStartLocation, projectileStartLocationFacingRight, projectileStartLocationFacingLeft, currentWeapon, projectile;

    private void Awake()
    {
        player_Controller = GetComponent<Player_Controller>();
        player_Animation = GetComponent<Player_Animation>();
    }

    private void Update()
    {
        FlipWeaponPosition();
    }

    public void AtemptShoot()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            GameObject newProjectile = Instantiate(projectile, projectileStartLocation.transform);
            newProjectile.transform.SetParent(GameManager_References.Instance.projectileParent.transform);
            player_Animation.IsAttacking();
        }
    }

    public void FlipWeaponPosition()
    {
        if (player_Controller.direction.x < -.1f || player_Controller.lastKnowDirection.x < -.1f)
        {
            currentWeapon.transform.SetPositionAndRotation(shootLeftPosition.position, shootLeftPosition.transform.rotation);
            projectileStartLocation.transform.SetPositionAndRotation(projectileStartLocationFacingLeft.transform.position, projectileStartLocationFacingLeft.transform.rotation);
        }
        else
        {
            currentWeapon.transform.SetPositionAndRotation(shootRightPosition.position, shootRightPosition.transform.rotation);
            projectileStartLocation.transform.SetPositionAndRotation(projectileStartLocationFacingRight.transform.position, projectileStartLocationFacingRight.transform.rotation);
        }
    }
}
