using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    Player_Controller player_Controller;
    Player_ProcessStats player_ProcessStats;
    Player_ParticleEffect player_ParticleEffect;

    public Collider2D triggerCollider;

    private void Awake()
    {
        player_Controller = GetComponent<Player_Controller>();
        player_ProcessStats = GetComponent<Player_ProcessStats>();
        player_ParticleEffect = GetComponent<Player_ParticleEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Base_Information otherInformation = collision.GetComponentInParent<Base_Information>();

        if (otherInformation != null)
        {
            Debug.Log("Player Hit - " + otherInformation._name);
            if (otherInformation._tag == "Enemy" && triggerCollider.IsTouching(otherInformation.GetComponent<Enemy_Collision>().triggerGO.GetComponent<Collider2D>()))
            {
                Debug.Log("Player - Hit Enemy!");
                player_ParticleEffect.SpawnParticleEffect();
                player_ProcessStats.ProcessDamage(otherInformation.damage);
                player_Controller.PlayerKnockBack(otherInformation.GetComponent<Enemy_Animation>().facingDirection, 1f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Base_Information otherInformation = collision.GetComponentInParent<Base_Information>();

        if (otherInformation != null)
        {

        }
    }
}
