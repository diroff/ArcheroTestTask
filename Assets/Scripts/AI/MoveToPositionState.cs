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
        Debug.Log("Move to position state");
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

        if (Vector3.Distance(_enemy.transform.position, _targetPosition) < ReachedThreshold)
        {
            _stateMachine.ChangeState(new IdleState(_enemy, _stateMachine));
        }
    }

    public void ExitState()
    {
    }

    private Vector3 FindNewPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _enemy.CalculateMovementRange();
        randomDirection += _enemy.transform.position;
        return new Vector3(randomDirection.x, _enemy.transform.position.y, randomDirection.z);
    }
}