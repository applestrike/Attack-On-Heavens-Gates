using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForTarget : IState
{
    private readonly Enemy _enemy;

    public SearchForTarget(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Tick()
    {
    }

    public void OnEnter()
    {
        // Debug.Log("Entering SearchForTarget State");
        GetTarget();
    }

    public void OnExit()
    {
        //  Debug.Log("Exiting SearchForTarget State");
    }

    void GetTarget()
    {
        _enemy.Target = RandomInsideCircle();
    }

    public Vector2 RandomInsideCircle()
    {
        _enemy.hasTarget = true;

        var randomPos = Random.insideUnitCircle * _enemy.randomPositionRadius;
        randomPos += (Vector2)_enemy.transform.position;
        return randomPos;
    }
}
