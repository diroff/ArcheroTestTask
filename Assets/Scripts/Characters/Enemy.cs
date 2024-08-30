public class Enemy : Fighter
{
    protected float MovementRange;
    protected float ImmobilityTime;

    private EnemyData _currentData;
    private StateMachine _stateMachine;

    protected override void Start()
    {
        base.Start();
        _stateMachine = new StateMachine();
        _stateMachine.ChangeState(new IdleState(this, _stateMachine));
    }

    protected override void Update()
    {
        base.Update();
        _stateMachine?.Update();
    }

    public override void SetData(CharacterData data)
    {
        base.SetData(data);

        _currentData = data as EnemyData;

        MovementRange = _currentData.MovementRange;
        ImmobilityTime = _currentData.ImmobilityTime;
    }

    public override float CalculateTotalAttackDelay()
    {
        return BaseAttackSpeed;
    }

    public override float CalculateTotalDamage()
    {
        return BaseDamage;
    }

    public float CalculateMovementRange()
    {
        return MovementRange;
    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}