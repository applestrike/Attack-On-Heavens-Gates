using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager_Sounds : MonoBehaviour
{
    #region Singleton 
    private static GameManager_Sounds _instance;

    public static GameManager_Sounds Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public AudioMixer masterMixer;
    public GameObject musicObject, SFXObject;
    public AudioSource musicSource, SFXSource;
    //   public AudioClip pickUp;
    //  public AudioClip[] musicClips;

    bool justOnce;

    void Start()
    {
        musicSource = musicObject.GetComponent<AudioSource>();
        SFXSource = SFXObject.GetComponent<AudioSource>();

        AdjustMasterVolume(0.5f);
        AdjustMusicVolume(0.5f);
        AdjustSFXVolume(1f);

        if (musicSource != null)
        {
            CallPlayMusic();
        }
    }

    void CallPlayMusic()
    {
        if (!justOnce)
        {
            justOnce = true;
            // StartCoroutine(PlayMusic());
        }
    }

    IEnumerator PlayMusic()
    {
        PickRandomSong();
        musicSource.Play();

        yield return new WaitForSeconds(musicSource.clip.length);

        justOnce = false;

        CallPlayMusic();
    }

    void PickRandomSong()
    {
        //   musicSource.clip = musicClips[Random.Range(0, musicClips.Length)];
    }

    public void AdjustMasterVolume(float newVolume)
    {
        masterMixer.SetFloat("Master Volume", Mathf.Log10(newVolume) * 20);
    }

    public void AdjustMusicVolume(float newVolume)
    {
        masterMixer.SetFloat("Music", Mathf.Log10(newVolume) * 20);
    }

    public void AdjustSFXVolume(float newVolume)
    {
        masterMixer.SetFloat("SFX", Mathf.Log10(newVolume) * 20);
    }
}
