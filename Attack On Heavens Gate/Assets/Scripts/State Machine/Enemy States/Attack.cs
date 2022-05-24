using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IState
{
    private readonly Enemy _enemy;
    private readonly Enemy_Collision _enemy_RangeDetection;

    public Attack(Enemy enemy, Enemy_Collision enemy_RangeDetection)
    {
        _enemy = enemy;
        _enemy_RangeDetection = enemy_RangeDetection;
    }

    public void Tick()
    {
        _enemy.Target = _enemy_RangeDetection.GetNearestPlayerPosition();
        AttackTarget();
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {

    }

    void AttackTarget()
    {

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.Target, Time.deltaTime * _enemy.attackMovementSpeed);
    }
}
