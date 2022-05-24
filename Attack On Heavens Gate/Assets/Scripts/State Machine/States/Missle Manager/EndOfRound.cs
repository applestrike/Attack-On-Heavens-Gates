public class EndOfRound : IState
{
    private readonly GameController missleFlowController;

    public EndOfRound(GameController missleFlowController)
    {
        this.missleFlowController = missleFlowController;
    }

    public void OnEnter()
    {
        missleFlowController.DebugLog("End Of Round");
        GameManager_UIManager.Instance.roundTextGO.GetComponent<UI_Color>().CallStartToFullColor();
      //  GameManager_UIManager.Instance.roundTextGO.GetComponent<UI_Color>().TMPText.text = "End Of Round " + missleFlowController.currentRound.ToString();
        GameManager_ScoreManager.Instance.CallAddUpScore();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
    }
}
