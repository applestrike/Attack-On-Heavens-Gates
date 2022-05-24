using UnityEngine;

public class UI_CleanUp : MonoBehaviour
{
    private void OnDisable()
    {
        UI_ScrollingTextMananger.Instance.RemoveFromList(gameObject);
    }
}
