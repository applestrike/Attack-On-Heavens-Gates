using System.Collections;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb2d;
    Player_Animation player_Animation;

    public Vector2 direction, lastKnowDirection, pushDirection;
    public float movementSpeed, pushTime, pushSpeed;
    public bool beingPushed;
    public Vector2 forceMultiper;

    bool justOnce;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player_Animation = GetComponent<Player_Animation>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        if (!beingPushed)
        {
            transform.Translate(direction * movementSpeed * Time.deltaTime);
            //rb2d.AddForce(direction * movementSpeed * Time.deltaTime);
            if (direction != Vector2.zero)
            {
                if (direction.y != 0)
                {
                    return;
                }
                else
                {
                    lastKnowDirection = direction;
                }
            }
        }
        else
        {
            PushBackUpdate();
        }

        player_Animation.FlipSprite();
    }

    public void PlayerKnockBack(Vector2 _pushDirection, float _time)
    {
        Debug.Log("Player Knock Back! " + _pushDirection + " < direction | time > " + _time);
        beingPushed = true;
        pushDirection = _pushDirection;
        pushTime = _time;

        CallPushCharacter();
    }

    void PushBackUpdate()
    {
        Debug.Log("UpdateCharacterPushBackPosition");
        transform.Translate(pushDirection * Time.deltaTime * pushSpeed);
    }

    void CallPushCharacter()
    {
        if (!justOnce)
        {
            StartCoroutine(PushCharacter());
        }
    }

    IEnumerator PushCharacter()
    {
        Debug.Log("Pushing Character!!");
        justOnce = true;
        yield return new WaitForSeconds(pushTime);
        beingPushed = false;
        justOnce = false;
    }

    void TurnOnPlayerGravity()
    {
        SetGravityScale(1);
    }
    void TurnOffPlayerGravity()
    {
        SetGravityScale(0);
    }

    void SetGravityScale(float number)
    {
        rb2d.gravityScale = number;
    }
}
