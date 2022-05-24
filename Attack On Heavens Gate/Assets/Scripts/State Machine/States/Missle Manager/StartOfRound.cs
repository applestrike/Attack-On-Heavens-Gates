public class StartOfRound : IState
{
    private readonly GameController missleFlowController;

    public StartOfRound(GameController missleFlowController)
    {
        this.missleFlowController = missleFlowController;
    }

    public void OnEnter()
    {
        missleFlowController.DebugLog("Start Of Round");
        GameManager_UIManager.Instance.roundTextGO.GetComponent<UI_Color>().CallStartToFullColor();
       // GameManager_UIManager.Instance.roundTextGO.GetComponent<UI_Color>().TMPText.text = "Round " + missleFlowController.currentRound.ToString();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
    }
}
