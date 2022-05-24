public class RoundPaused : IState
{
    private readonly GameController missleFlowController;

    public RoundPaused(GameController missleFlowController)
    {
        this.missleFlowController = missleFlowController;
    }

    public void OnEnter()
    {
        missleFlowController.DebugLog("Missle Pause");
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
    }
}
