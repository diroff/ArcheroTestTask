public class SimpleHitWeapon : MeleeWeapon
{
    protected SimpleMeleeWeaponData Data;

    public SimpleHitWeapon(WeaponData data, Fighter owner) : base(data, owner)
    {
        Data = data as SimpleMeleeWeaponData;
    }

    public override void Attack(IDamagable target)
    {
        target.TakeDamage(CalculateDamage());
    }

    protected override float CalculateDamage()
    {
        var damage = Owner.CalculateTotalDamage() + BaseAttackDamage;

        return damage;
    }
}