using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    protected Projectile ProjectilePrefab;

    public RangedWeapon(WeaponData data, Fighter owner) : base(data, owner) { }

    public void SetProjectilePrefab(Projectile projectilePrefab)
    {
        ProjectilePrefab = projectilePrefab;
    }

    protected virtual void CreateAndLaunchProjectile(Vector3 direction)
    {
        Projectile projectileInstance = GameObject.Instantiate(ProjectilePrefab, Owner.GetWeaponPlacement().transform.position, Quaternion.identity);
        projectileInstance.SetData(ProjectilePrefab.CurrentData, this);

        projectileInstance.Launch(direction);
    }

    public override float CalculateDamage()
    {
        return BaseAttackDamage + Owner.CalculateTotalDamage();
    }
}