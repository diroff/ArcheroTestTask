using System.Collections;
using UnityEngine;

public abstract class Weapon : IWeapon
{
    protected float BaseAttackDelay;
    protected float BaseAttackDamage;

    protected WeaponData WeaponData;

    private bool _canAttack = true;

    public Fighter Owner { get; protected set; }

    public Weapon(WeaponData data, Fighter owner)
    {
        WeaponData = data;

        BaseAttackDelay = WeaponData.BaseAttackDelay;
        BaseAttackDamage = WeaponData.BaseAttackDamage;

        Owner = owner;

        _canAttack = true;
    }

    public virtual void Attack(IDamagable target)
    {
        if (!_canAttack)
            return;

        PerformAttack(target);
        _canAttack = false;
        Owner.StartCoroutine(AttackCoolDown());
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(GetAttackDelay());
        _canAttack = true;
    }

    protected virtual float GetAttackDelay()
    {
        return BaseAttackDelay + Owner.CalculateTotalAttackDelay();
    }

    protected virtual void PerformAttack(IDamagable target) { }

    public abstract float CalculateDamage();
}