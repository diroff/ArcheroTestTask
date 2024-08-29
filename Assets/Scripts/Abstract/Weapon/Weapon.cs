public abstract class Weapon : IWeapon
{
    protected float BaseAttackSpeed;
    protected float BaseAttackDamage;

    protected WeaponData WeaponData;

    public Fighter Owner { get; protected set; }

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