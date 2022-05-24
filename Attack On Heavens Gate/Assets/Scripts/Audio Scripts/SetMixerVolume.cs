using UnityEngine;

public class SetMixerVolume : MonoBehaviour
{
    public void SetMasterMixVolume()
    {
        GameManager_Sounds.Instance.AdjustMasterVolume(UI_Manager.Instance.masterVolumeSlider.value);
    }

    public void SetMusicVol(float soundLevel)
    {
        //   masterMixer.SetFloat("Music", soundLevel);
    }

    public void SetSFXVol(float soundLevel)
    {
        // masterMixer.SetFloat("SFX", soundLevel);
    }
}