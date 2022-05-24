using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    #region Singleton
    private static UI_Manager _instance;

    public static UI_Manager Instance { get { return _instance; } }


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

    public Button playButton, optionButton, exitButton, playButtonGameOver, mainMenuGameOver, optionsMenuMain;
    public GameObject mainMenu, pauseMenu, optionsMenu, gameOverMenu, gamePlayUI, scrollingTextPrefab, scrollingTextSpacer, baseOneAmmo,baseTwoAmmo,baseThreeAmmo, roundText,splashScreen;
    public Slider masterVolumeSlider, musicVolumeSlider, SFXVolumeSlider;
    public Toggle masterVolumeToggle;

    private void Start()
    {
        AddListenersForButtons();
    }

    void AddListenersForButtons()
    {
        playButton.onClick.AddListener(PlayButton);
        optionButton.onClick.AddListener(OptionsButton);
        exitButton.onClick.AddListener(ExitButton);
        playButtonGameOver.onClick.AddListener(PlayButtonGameOver);
        mainMenuGameOver.onClick.AddListener(MainMenuGameOver);
        optionsMenuMain.onClick.AddListener(OptionsMenuMain);
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void OnStartOfRound()
    {
        roundText.GetComponent<UI_Color>().CallStartToFullColor();
    }

    public void PlayButton()
    {
        Debug.Log("Clicking PlayButton button");
        if (GameManager.IsInputEnabled)
        {
            if (mainMenu.activeSelf)
            {
                DisableMainMenu();
            }
            else
            {
                EnableMainMenu();
            }
            SceneLoader.Instance.CallLoadNextScene("GamePlay", 0, true);
            Debug.Log("PlayButton");
        }
    }

    public void OptionsButton()
    {
        if (GameManager.IsInputEnabled)
        {
            Debug.Log("Clicking options button");

            EnableOptionMenu();
            DisableMainMenu();
        }
    }

    public void ExitButton()
    {
        if (GameManager.IsInputEnabled)
        {
            Debug.Log("Clicking exit button");
            Application.Quit();
        }
    }
    public void EnableOptionMenu()
    {
        if (GameManager.IsInputEnabled)
        {
            optionsMenu.SetActive(true);
            SetMasterVolume(0.5f);
            SetMusicVolume(0.5f);
            SetSFXVolume(0.5f);
        }
    }
    public void DisableOptionMenu()
    {
        if (GameManager.IsInputEnabled)
        {
            optionsMenu.SetActive(false);
        }
    }
    public void EnableMainMenu()
    {
        if (GameManager.IsInputEnabled)
        {
            Debug.Log("Enabling Main Menu");
            mainMenu.SetActive(true);
        }
    }

    public void DisableMainMenu()
    {
        if (GameManager.IsInputEnabled)
        {
            mainMenu.SetActive(false);
        }
    }

    public void EnableGameOverMenu()
    {
        if (GameManager.IsInputEnabled)
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void DisableGameOverMenu()
    {
        if (GameManager.IsInputEnabled)
        {
            gameOverMenu.SetActive(false);
        }
    }

    public void PlayButtonGameOver()
    {
        if (GameManager.IsInputEnabled)
        {
            Debug.Log("Play Button Game Over");
            DisableMainMenu();
            DisableGameOverMenu();
            GameManager.Instance.OnGamePlay();
        }
    }
    public void MainMenuGameOver()
    {
        if (GameManager.IsInputEnabled)
        {
            if (gameOverMenu.activeSelf)
            {
                DisableGameOverMenu();
            }
            else
            {
                DisableGameOverMenu();
            }
            SceneLoader.Instance.CallLoadNextScene("MainMenu", 0,false);
        }
    }

    public void OptionsMenuMain()
    {
        if (GameManager.IsInputEnabled)
        {
            if (optionsMenu.activeSelf)
            {
                Debug.Log("Back To Main Menu");
                EnableMainMenu();
                DisableOptionMenu();
            }
        }
    }

    public void EnableGamePlayUI()
    {
        if (GameManager.IsInputEnabled)
        {
            gamePlayUI.SetActive(true);
        }
    }
    public void DisableGamePlayUI()
    {
        if (GameManager.IsInputEnabled)
        {
            gamePlayUI.SetActive(false);
        }
    }

    public void SetMasterVolume(float value)
    {
        if (optionsMenu.activeSelf)
        {
            masterVolumeSlider.value = value;
            GameManager_Sounds.Instance.masterMixer.SetFloat("Master Volume", Mathf.Log10(value) * 20);
        }
    }
    public void SetMusicVolume(float value)
    {
        if (optionsMenu.activeSelf)
        {
            musicVolumeSlider.value = value;
            GameManager_Sounds.Instance.masterMixer.SetFloat("Music", Mathf.Log10(value) * 20);
        }
    }
    public void SetSFXVolume(float value)
    {
        if (optionsMenu.activeSelf)
        {
            SFXVolumeSlider.value = value;
            GameManager_Sounds.Instance.masterMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        }
    }

    public void EnableSplashScreen()
    {
        splashScreen.SetActive(true);
        splashScreen.GetComponent<UI_Color>().CallStartToFullColor();
    }
}
