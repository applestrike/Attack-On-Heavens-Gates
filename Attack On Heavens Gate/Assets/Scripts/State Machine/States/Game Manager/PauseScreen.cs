public class PauseScreen : IState
{
    private readonly GameManagerController gameManagerController;

    public PauseScreen(GameManagerController gameManagerController)
    {
        this.gameManagerController = gameManagerController;
    }

    public void OnEnter()
    {
        gameManagerController.DebugLog("Pause Screen");
        GameManagerController.Instance.currentState = GameManagerController.GameStates.PauseScreen;
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
