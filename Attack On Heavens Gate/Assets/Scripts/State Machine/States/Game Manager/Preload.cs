using UnityEngine;

public class Preload : IState
{
    private readonly GameManagerController gameManagerController;

    public Preload(GameManagerController gameManagerController)
    {
        this.gameManagerController = gameManagerController;
    }

    public void OnEnter()
    {
        Debug.Log("Preload");
        Scene_Manager.Instance.currentScene = Scene_Manager.Scenes.Preload;
        Scene_Manager.Instance.CallNextScene(.1f,Scene_Manager.Scenes.SplashScreen, .1f,false);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
