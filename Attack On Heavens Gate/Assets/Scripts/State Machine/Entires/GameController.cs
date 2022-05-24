using System;
using System.Collections;
using UnityEngine;
public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance { get { return _instance; } }

    private StateMachine _stateMachine;

    public GameStates currentState;

    public bool startGamePlay;

    public enum GameStates
    {
        RoundPaused,
        StartOfRound,
        FireMissles,
        EndOfRound
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        _stateMachine = new StateMachine();

        var roundPaused = new RoundPaused(this);
        var startOfRound = new StartOfRound(this);
        var missleFire = new MissleFire(this);
        var endOfRound = new EndOfRound(this);

        At(startOfRound, missleFire, Fire());
        At(missleFire, endOfRound, EndOfRound());
        At(endOfRound, startOfRound, StartOfRound());

        _stateMachine.SetState(roundPaused);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> StartOfRound() => () => currentState == GameStates.StartOfRound;
        Func<bool> Fire() => () => currentState == GameStates.FireMissles;
        Func<bool> EndOfRound() => () => currentState == GameStates.EndOfRound;
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    public void DebugLog(string name)
    {
        Debug.Log(name);
    }

    public void PauseRound()
    {
        currentState = GameStates.RoundPaused;
    }

    public void StartRound()
    {
        currentState = GameStates.StartOfRound;
    }

    public void EndRound()
    {
        currentState = GameStates.EndOfRound;
    }
}
