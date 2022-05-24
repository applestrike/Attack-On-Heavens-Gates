
using UnityEngine;
public class MissleFire : IState
{
    private readonly GameController missleFlowController;

    public MissleFire(GameController missleFlowController)
    {
        this.missleFlowController = missleFlowController;
    }

    public void OnEnter()
    {
        missleFlowController.DebugLog("Missle Fire");
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
    }
}
