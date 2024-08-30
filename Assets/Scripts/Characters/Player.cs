public class Player : Fighter
{
    private PlayerData _currentData;

    public override void SetData(CharacterData data)
    {
        base.SetData(data);

        _currentData = data as PlayerData;
    }

    public override float CalculateTotalAttackDelay()
    {
        return BaseAttackSpeed;
    }

    public override float CalculateTotalDamage()
    {
        return BaseDamage;
    }

    public override float ReturnTargetZoneDetection()
    {
        return BaseAttackRange;
    }
}