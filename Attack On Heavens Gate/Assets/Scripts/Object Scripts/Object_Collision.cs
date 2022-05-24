using UnityEngine;

public class Object_Collision : MonoBehaviour
{
    Object_ParticleEffect object_ParticleEffect;
    Object_Health object_Health;
    Object_Death object_Death;
    Object_Information object_Information;
    Object_Teleport object_Teleport;

    public Collider2D triggerCollider;

    private void Awake()
    {
        object_ParticleEffect = GetComponent<Object_ParticleEffect>();
        object_Health = GetComponent<Object_Health>();
        object_Death = GetComponent<Object_Death>();
        object_Information = GetComponent<Object_Information>();
        object_Teleport = GetComponent<Object_Teleport>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Base_Information otherInformation = collision.GetComponentInParent<Base_Information>();

        if (otherInformation != null)
        {
            //if (otherInformation._tag == "Player" && object_Information._tag == "Teleporter" && triggerCollider.GetComponent<Collider2D>().IsTouching(collision))
            //{
            //    Debug.Log(object_Information._GO);
            //    Debug.Log(otherInformation._name + "Attemping teleporting");
            //    object_Teleport.TeleportObject(otherInformation.gameObject);
            //}

            //if (otherInformation._tag == "Player" && object_Information._tag == "Teleporter" && triggerCollider.GetComponent<Collider2D>().IsTouching(collision))
            //{
            //    Debug.Log("Golden Gate");
            //    object_Teleport.TeleportObject(otherInformation.gameObject);
            //}
            if (otherInformation._tag == "Player" && object_Information._name == "Green Sparkle" && triggerCollider.GetComponent<Collider2D>().IsTouching(collision))
            {
                otherInformation.GetComponent<Base_ProcessStats>().ProcessHealing(object_Information.healing);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Base_Information otherInformation = collision.GetComponentInParent<Base_Information>();

        if (otherInformation != null)
        {
            if (otherInformation._tag == "Player" && object_Information._name == "Green Sparkle" && triggerCollider.GetComponent<Collider2D>().IsTouching(collision))
            {
                otherInformation.GetComponent<Base_ProcessStats>().ProcessHealing(object_Information.healing);
            }
        }
    }
}
