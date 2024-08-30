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
        _enemy.AttackStrategy();
    }

    public void UpdateState()
    {
        _enemy.AttackStrategy();

        if (!_enemy.TargetIsActive())
        {
            _stateMachine.ChangeState(new IdleState(_enemy, _stateMachine));
            return;
        }
    }

    public void ExitState()
    {

    }
}