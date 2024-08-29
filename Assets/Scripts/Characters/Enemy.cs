public class Enemy : Fighter
{
    protected float MovementRange;
    protected float ImmobilityTime;

    private EnemyData _currentData;

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

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}