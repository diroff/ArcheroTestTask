using UnityEngine;

public class MoveToPositionState : IState
{
    private readonly Enemy _enemy;
    private readonly StateMachine _stateMachine;

    private Vector3 _targetPosition;
    private const float ReachedThreshold = 0.1f;

    public MoveToPositionState(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        _targetPosition = FindNewPosition();
    }

    public void UpdateState()
    {
        if (_enemy.TargetIsActive())
        {
            _stateMachine.ChangeState(new AttackState(_enemy, _stateMachine));
            return;
        }

        Vector3 direction = (_targetPosition - _enemy.transform.position).normalized;
        _enemy.Move(direction);

        if (HasReachedTarget())
            _stateMachine.ChangeState(new IdleState(_enemy, _stateMachine));
    }

    public void ExitState() { }

    private Vector3 FindNewPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _enemy.CalculateMovementRange();
        randomDirection += _enemy.transform.position;
        return new Vector3(randomDirection.x, _enemy.transform.position.y, randomDirection.z);
    }

    private bool HasReachedTarget()
    {
        Vector2 currentPositionXZ = new Vector2(_enemy.transform.position.x, _enemy.transform.position.z);
        Vector2 targetPositionXZ = new Vector2(_targetPosition.x, _targetPosition.z);

        return Vector2.Distance(currentPositionXZ, targetPositionXZ) < ReachedThreshold;
    }
}