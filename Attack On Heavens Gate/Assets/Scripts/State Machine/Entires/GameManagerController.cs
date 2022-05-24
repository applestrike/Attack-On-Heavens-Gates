using System;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    private static GameManagerController _instance;

    public static GameManagerController Instance { get { return _instance; } }

    private StateMachine _stateMachine;

    public GameStates currentState;

    public enum GameStates
    {
        Preload,
        SplashScreen,
        MainMenu,
        PauseScreen,
        GamePlay,
        GameOver
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        _stateMachine = new StateMachine();

        var preLoad = new Preload(this);
        var splashScreen = new SplashScreen(this);
        var mainMenu = new MainMenu(this);
        var pauseScreen = new PauseScreen(this);
        var gamePlay = new GamePlay(this);
        var gameOver = new GameOver(this);

        At(preLoad, splashScreen, SplashScreen());
        At(splashScreen, mainMenu, MainMenu());

        At(mainMenu, gamePlay, GamePlay());

        At(gamePlay, pauseScreen, PauseScreen());
        At(gamePlay, gameOver, GameOver());

        At(pauseScreen, mainMenu, MainMenu());
        At(pauseScreen, gamePlay, GamePlay());

        At(gameOver, mainMenu, MainMenu());
        At(gameOver, gamePlay, GamePlay());

        // _stateMachine.AddAnyTransition(decision, Stuck());

        _stateMachine.SetState(preLoad);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);


        Func<bool> MainMenu() => () => currentState == GameStates.MainMenu;
        Func<bool> SplashScreen() => () => currentState == GameStates.SplashScreen;
        Func<bool> PauseScreen() => () => currentState == GameStates.PauseScreen;
        Func<bool> GamePlay() => () => currentState == GameStates.GamePlay;
        Func<bool> GameOver() => () => currentState == GameStates.GameOver;
        //    Func<bool> Transition() => () => currentState == GameStates.Transition;
    }

    public void UpdateCurrentState()
    {
        if(Scene_Manager.Instance.currentSceneName == Scene_Manager.Scenes.Preload.ToString())
        {
            currentState = GameStates.Preload;
            Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.Preload;
        }
        else if (Scene_Manager.Instance.currentSceneName == Scene_Manager.Scenes.SplashScreen.ToString())
        {
            currentState = GameStates.SplashScreen;
            Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.SplashScreen;
        }
        else if (Scene_Manager.Instance.currentSceneName == Scene_Manager.Scenes.MainMenu.ToString())
        {
            currentState = GameStates.MainMenu;
            Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.MainMenu;
        }
        else if (Scene_Manager.Instance.currentSceneName == Scene_Manager.Scenes.GamePlay.ToString())
        {
            currentState = GameStates.GamePlay;
            Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.GamePlay;
        }
    }
    private void Update() => _stateMachine.Tick();

    public void DebugLog(string name)
    {
        Debug.Log(name);
    }
}
