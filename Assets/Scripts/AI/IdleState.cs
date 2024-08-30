using UnityEngine;

public class IdleState : IState
{
    private readonly Enemy _enemy;
    private readonly StateMachine _stateMachine;
    private float _remainingTime;

    public IdleState(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        Debug.Log("Idle state");
        _remainingTime = _enemy.CalculateImmobilityTime();
    }

    public void UpdateState()
    {
        if (_enemy.TargetIsActive())
        {
            _stateMachine.ChangeState(new AttackState(_enemy, _stateMachine));
            return;
        }

        _remainingTime -= Time.deltaTime;

        if (_remainingTime <= 0f)
            _stateMachine.ChangeState(new MoveToPositionState(_enemy, _stateMachine));
    }

    public void ExitState()
    {

    }
}