public class Player : Fighter
{
    private PlayerData _currentData;

    public override void SetData(CharacterData data)
    {
        base.SetData(data);

        _currentData = data as PlayerData;
    }

    public override float CalculateTotalAttackSpeed()
    {
        return BaseAttackSpeed;
    }

    public override float CalculateTotalDamage()
    {
        return BaseDamage;
    }
}