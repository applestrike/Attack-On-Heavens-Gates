using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    SpriteRenderer playerSR;
    Player_Controller playerController;

    public Animator playerAnimator, weaponAnimator;

    void InitialReferences()
    {
        playerSR = GetComponentInChildren<SpriteRenderer>();
        playerController = GetComponent<Player_Controller>();
    }

    private void Awake()
    {
        InitialReferences();
    }

    public void FlipSprite()
    {
        if (playerController.direction == Vector2.zero)
        {
            if (playerController.lastKnowDirection.x < -.1f)
            {
                playerSR.flipX = true;
            }
            else
            {
                playerSR.flipX = false;
            }
        }
        else
        {
            if (playerController.direction.x < -.1f)
            {
                playerSR.flipX = true;
            }
            else
            {
                playerSR.flipX = false;
            }
        }
    }
    public void IsAttacking()
    {
        Debug.Log("On Attack");
        weaponAnimator.SetTrigger("IsAttacking");
    }
}

