public abstract class RangedWeapon : Weapon
{
    protected Projectile Projectile;

    protected RangedWeapon(WeaponData data, Fighter owner) : base(data, owner) { }

    public void SetProjectile(Projectile projectile)
    {
        Projectile = projectile;
    }

    public override void Attack(IDamagable target)
    {
        if (Projectile == null)
            return;

        Projectile.Launch(Owner.GetCurrentDirection());
    }

    public override float CalculateDamage()
    {
        return BaseAttackDamage + Owner.CalculateTotalDamage();
    }
}