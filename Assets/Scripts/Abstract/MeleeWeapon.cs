public abstract class MeleeWeapon : Weapon
{
    protected MeleeWeapon(WeaponData data, Fighter owner) : base(data, owner) { }

    protected override float CalculateDamage()
    {
        return BaseAttackDamage + Owner.CalculateTotalDamage();
    }
}