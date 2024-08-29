using UnityEngine;

public class WeaponTester : MonoBehaviour
{
    [SerializeField] private SingleShotWeaponData _singleShotWeaponData;
    [SerializeField] private SplitShotWeaponData _splitShotWeaponData;

    [SerializeField] private Projectile _bulletPrefab;
    [SerializeField] private ProjectileData _bulletData;

    [SerializeField] private FighterCreatorTester _creatorTester;

    private Player _player;
    private Enemy _currentEnemy;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AttackEnemy();

        if (Input.GetKeyDown(KeyCode.P))
            SetupSingleShotWeapon();

        if (Input.GetKeyDown(KeyCode.S))
            SetupSplitShotWeapon();
    }

    public void SetupSingleShotWeapon()
    {
        if(_player == null)
            _player = _creatorTester.GetPlayer();

        SetPlayerWeapon(new SingleShotWeapon(_singleShotWeaponData, _player));
    }

    public void SetupSplitShotWeapon()
    {
        if (_player == null)
            _player = _creatorTester.GetPlayer();

        SetPlayerWeapon(new SplitShotWeapon(_splitShotWeaponData, _player));
    }

    private void SetPlayerWeapon(RangedWeapon weapon)
    {
        _player = _creatorTester.GetPlayer();

        weapon.SetProjectilePrefab(_bulletPrefab);
        _player.SetWeapon(weapon);
    }

    public void AttackEnemy()
    {
        if (_player == null)
            return;

        _player.Attack();
    }
}