public class GamePlay : IState
{
    private readonly GameManagerController gameManagerController;

    public GamePlay(GameManagerController gameManagerController)
    {
        this.gameManagerController = gameManagerController;
    }

    public void OnEnter()
    {
        gameManagerController.DebugLog("Game Play");
        GameManagerController.Instance.currentState = GameManagerController.GameStates.GamePlay;
        Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.GamePlay;
        GameManager.Instance.OnGamePlay();
        GameManager.Instance.EnableEnvironment();
        UI_Manager.Instance.EnableGamePlayUI();
        UI_Manager.Instance.OnStartOfRound();
        GameController.Instance.StartRound();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
