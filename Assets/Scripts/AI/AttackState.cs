public class AttackState : IState
{
    private readonly Enemy _enemy;
    private readonly StateMachine _stateMachine;

    public AttackState(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        _enemy.Attack();
    }

    public void UpdateState()
    {
        if (!_enemy.TargetIsActive())
            _stateMachine.ChangeState(new IdleState(_enemy, _stateMachine));
        else if (_enemy.IsMoving())
            _stateMachine.ChangeState(new MoveToPositionState(_enemy, _stateMachine));
    }

    public void ExitState()
    {

    }
}