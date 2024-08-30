public class StateMachine
{
    private IState _currentState;

    public void Update()
    {
        _currentState?.UpdateState();
    }

    public void ChangeState(IState newState)
    {
        _currentState?.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }
}