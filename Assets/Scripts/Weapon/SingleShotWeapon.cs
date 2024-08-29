using UnityEngine;

public class SingleShotWeapon : RangedWeapon
{
    protected SingleShotWeaponData SingleShotData;

    public SingleShotWeapon(SingleShotWeaponData data, Fighter owner) : base(data, owner) 
    {
        SingleShotData = data;
    }

    protected override void PerformAttack(IDamagable target)
    {
        if (ProjectilePrefab == null)
            return;

        Vector3 direction = Owner.GetCurrentDirection();

        CreateAndLaunchProjectile(direction);
    }
}
