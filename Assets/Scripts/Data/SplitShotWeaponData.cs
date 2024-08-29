using UnityEngine;

[CreateAssetMenu(fileName = "SplitShotWeaponData", menuName = "Create Data/Weapon/Ranged Weapon/New Split Shot Weapon Data", order = 51)]
public class SplitShotWeaponData : WeaponData
{
    [field: SerializeField] public int BulletCount { get; private set; }
    [field: SerializeField, Range(0, 1)] public float Accuracy { get; private set; }
}