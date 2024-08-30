using UnityEngine;

public class MoveToPositionState : IState
{
    private readonly Enemy _enemy;
    private readonly StateMachine _stateMachine;
    private Vector3 _targetPosition;

    public MoveToPositionState(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        _targetPosition = FindNewPosition();
        _enemy.Move(_targetPosition - _enemy.transform.position);
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

        if (Vector3.Distance(_enemy.transform.position, _targetPosition) < 0.1f)
            _stateMachine.ChangeState(new IdleState(_enemy, _stateMachine));
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