using System.Collections.Generic;
using UnityEngine;

public class RandomWeaponTester : MonoBehaviour
{
    [SerializeField] private List<WeaponData> _availableWeapons;

    [SerializeField] private Projectile _bulletPrefab;
    [SerializeField] private ProjectileData _bulletData;

    [SerializeField] private Fighter _fighter;

    private void Start()
    {
        AssignRandomWeaponToFighter();
    }

    private void AssignRandomWeaponToFighter()
    {
        if (_availableWeapons == null || _availableWeapons.Count == 0 || _fighter == null)
            return;

        WeaponData randomWeaponData = GetRandomWeaponData();
        RangedWeapon randomWeapon = CreateWeaponFromData(randomWeaponData);

        if (randomWeapon == null)
            return;

        randomWeapon.SetProjectilePrefab(_bulletPrefab);
        _fighter.SetWeapon(randomWeapon);
        Debug.Log("weapon created!");
    }

    private WeaponData GetRandomWeaponData()
    {
        int randomIndex = Random.Range(0, _availableWeapons.Count);
        return _availableWeapons[randomIndex];
    }

    private RangedWeapon CreateWeaponFromData(WeaponData weaponData)
    {
        if (weaponData is SingleShotWeaponData singleShotData)
            return new SingleShotWeapon(singleShotData, _fighter);

        else if (weaponData is SplitShotWeaponData splitShotData)
            return new SplitShotWeapon(splitShotData, _fighter);

        return null;
    }
}