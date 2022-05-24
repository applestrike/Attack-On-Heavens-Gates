using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{
    private readonly Enemy _devilTongue;

    public Idle(Enemy devilTongue)
    {
        _devilTongue = devilTongue;
    }

    public void Tick()
    {
        GoIdle();
    }

    public void OnEnter()
    {
        Debug.Log("Entering Idle State");
    }

    public void OnExit()
    {
        Debug.Log("Exiting Idle State");
    }

    void GoIdle()
    {
        Debug.Log("Going Idle");
        _devilTongue.moveSpeed = 0;
        _devilTongue.hasTarget = false;
    }
}
