public class GameOver : IState
{
    private readonly GameManagerController gameManagerController;

    public GameOver(GameManagerController gameManagerController)
    {
        this.gameManagerController = gameManagerController;
    }

    public void OnEnter()
    {
        gameManagerController.DebugLog("GamePlay");
        GameManagerController.Instance.currentState = GameManagerController.GameStates.GameOver;
        UI_Manager.Instance.EnableGameOverMenu();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
