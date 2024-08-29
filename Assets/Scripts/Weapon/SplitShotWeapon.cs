using UnityEngine;

public class SplitShotWeapon : RangedWeapon
{
    protected SplitShotWeaponData SplitShotData;

    public SplitShotWeapon(SplitShotWeaponData data, Fighter owner) : base(data, owner) 
    {
        SplitShotData = data;
    }

    public override void Attack(IDamagable target)
    {
        if (ProjectilePrefab == null)
            return;

        Vector3 direction = Owner.GetCurrentDirection();

        CreateAndLaunchProjectiles(direction);
    }

    private void CreateAndLaunchProjectiles(Vector3 direction)
    {
        int bulletCount = SplitShotData.BulletCount;
        float accuracy = SplitShotData.Accuracy;

        float maxSpreadAngle = (1 - accuracy) * 180f;

        for (int i = 0; i < bulletCount; i++)
        {
            float angleOffset = (i - (bulletCount - 1) / 2f) * (maxSpreadAngle / (bulletCount - 1));
            Quaternion rotationOffset = Quaternion.Euler(0, angleOffset, 0);
            Vector3 spreadDirection = rotationOffset * direction;

            CreateAndLaunchProjectile(spreadDirection);
        }
    }
}