using UnityEngine;

public class Player_Input : MonoBehaviour
{
    Player_Controller player_Controller;
    Player_Shoot player_Shoot;
    private void Awake()
    {
        player_Controller = GetComponent<Player_Controller>();
        player_Shoot = GetComponent<Player_Shoot>();
    }

    private void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        player_Controller.direction.x = Input.GetAxisRaw("Horizontal");
        player_Controller.direction.y = Input.GetAxisRaw("Vertical");
    }

    void PlayerShoot()
    {
        if (Input.GetButton("Fire1"))
        {
            player_Shoot.AtemptShoot();
        }
    }
}
