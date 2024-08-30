public class IdleState : IState
{
    private readonly Enemy _enemy;
    private readonly StateMachine _stateMachine;

    public IdleState(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {

    }

    public void UpdateState()
    {
        if (_enemy.TargetIsActive() && !_enemy.IsMoving())
            _stateMachine.ChangeState(new AttackState(_enemy, _stateMachine));
        else
            _stateMachine.ChangeState(new MoveToPositionState(_enemy, _stateMachine));
    }

    public void ExitState()
    {

    }
}