public class SplashScreen : IState
{
    private readonly GameManagerController gameManagerController;

    public SplashScreen(GameManagerController gameManagerController)
    {
        this.gameManagerController = gameManagerController;
    }

    public void OnEnter()
    {
        gameManagerController.DebugLog("Splash Screen");
        GameManager.IsInputEnabled = false;
        GameManagerController.Instance.currentState = GameManagerController.GameStates.SplashScreen;
        Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.SplashScreen;
        Scene_Manager.Instance.CallNextScene(.1f, Scene_Manager.Scenes.MainMenu, 5f, true);
        UI_Manager.Instance.EnableSplashScreen();
    }

    public void OnExit()
    {
        GameManager.IsInputEnabled = true;
    }

    public void Tick()
    {
    }
}
