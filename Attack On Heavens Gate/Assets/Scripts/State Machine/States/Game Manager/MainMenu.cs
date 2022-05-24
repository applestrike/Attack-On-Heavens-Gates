public class MainMenu : IState
{
    private readonly GameManagerController gameManagerController;

    public MainMenu(GameManagerController gameManagerController)
    {
        this.gameManagerController = gameManagerController;
    }

    public void OnEnter()
    {
        gameManagerController.DebugLog("Main Menu");
        GameManagerController.Instance.currentState = GameManagerController.GameStates.MainMenu;
        Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.MainMenu;
        UI_Manager.Instance.EnableMainMenu();
        UI_Manager.Instance.DisableGamePlayUI();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
    }
}
