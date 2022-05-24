using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : IState
{
    private readonly Enemy _enemy;

    private Vector2 _lastPosition = Vector2.zero;

    public float TimeStuck;


    public Move(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Tick()
    {
        if (_enemy.hasTarget)
        {
            if (Vector2.Distance(_enemy.transform.position, _lastPosition) <= _enemy.StuckTime)
            {
                //   Debug.Log("Stuck!");
                TimeStuck += Time.deltaTime;
            }


            _lastPosition = _enemy.transform.position;

            if (_enemy.Target != null)
                MoveToTarget();
        }
    }

    public void OnEnter()
    {
        // Debug.Log("Entering Move State");

        TimeStuck = 0;
    }

    public void OnExit()
    {
        // Debug.Log("Exiting Move State");
        _enemy.hasTarget = false;
    }

    void MoveToTarget()
    {
        //   Debug.Log("Move To Target");
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.Target, Time.deltaTime * _enemy.moveSpeed);
    }

}
