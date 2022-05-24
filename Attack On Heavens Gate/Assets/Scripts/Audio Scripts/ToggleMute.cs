using UnityEngine;

public class ToggleMute : MonoBehaviour
{

    public void ToggleMuteMasterVolume()
    {
        if (UI_Manager.Instance.masterVolumeToggle.isOn)
        {
            GameManager_Sounds.Instance.AdjustMasterVolume(-80f);
        }
        else
        {
            GameManager_Sounds.Instance.AdjustMasterVolume(0f);
        }
    }
}
