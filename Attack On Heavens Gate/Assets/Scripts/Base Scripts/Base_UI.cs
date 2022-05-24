using UnityEngine;
using UnityEngine.UI;

public class Base_UI : MonoBehaviour
{
    Base_Health base_Health;

    public Image content;

    private void Awake()
    {
        base_Health = GetComponent<Base_Health>();
    }

    public void UpdateHealthBar()
    {
        if (content != null)
        {
            float ratio = (float)base_Health.currentHealth / (float)base_Health.maxHealth;
            content.rectTransform.localScale = new Vector3(ratio, 1.5f, 1);
        }
    }
}
