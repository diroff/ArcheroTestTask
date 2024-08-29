public abstract class Weapon : IWeapon
{
    protected float BaseAttackSpeed;
    protected float BaseAttackDamage;

    protected WeaponData WeaponData;
    protected Fighter Owner;

    public Weapon(WeaponData data, Fighter owner)
    {
        WeaponData = data;

        BaseAttackSpeed = WeaponData.BaseAttackSpeed;
        BaseAttackDamage = WeaponData.BaseAttackDamage;

        Owner = owner;
    }

    public virtual void Attack(IDamagable target) { }

    public abstract float CalculateDamage();
}