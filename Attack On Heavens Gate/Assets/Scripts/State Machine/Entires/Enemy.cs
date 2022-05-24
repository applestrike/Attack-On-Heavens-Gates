using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private StateMachine _stateMachine;

    public float moveSpeed, attackMovementSpeed, StuckTime, randomPositionRadius, reachedTargetMinRange;
    public bool hasTarget;
    public Vector2 Target;

    private void Awake()
    {
        var enemyDetector = gameObject.GetComponent<Enemy_Collision>();

        _stateMachine = new StateMachine();

        var searchForTarget = new SearchForTarget(this);
        var idle = new Idle(this);
        var move = new Move(this);
        var attack = new Attack(this, enemyDetector);

        At(searchForTarget, move, HasTarget());
        At(move, searchForTarget, StuckForOverASecond());
        At(move, searchForTarget, ReachedTarget());

        _stateMachine.AddAnyTransition(attack, () => enemyDetector.EnemyInRange);

        At(attack, searchForTarget, () => enemyDetector.EnemyInRange == false);

        _stateMachine.SetState(searchForTarget);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> HasTarget() => () => hasTarget;
        Func<bool> StuckForOverASecond() => () => move.TimeStuck > 1;
        Func<bool> ReachedTarget() => () => Target != null && Vector2.Distance(transform.position, Target) < reachedTargetMinRange;
    }

    private void Update() => _stateMachine.Tick();
}
