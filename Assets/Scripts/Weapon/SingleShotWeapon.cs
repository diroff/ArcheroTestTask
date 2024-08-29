using UnityEngine;

public class SingleShotWeapon : RangedWeapon
{
    public SingleShotWeapon(WeaponData data, Fighter owner) : base(data, owner) { }

    public override void Attack(IDamagable target)
    {
        if (ProjectilePrefab == null)
            return;

        Vector3 direction = Owner.GetCurrentDirection();

        CreateAndLaunchProjectile(direction);
    }
}
