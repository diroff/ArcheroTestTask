using UnityEngine;
using UnityEngine.Events;

public abstract class Fighter : Character, IDamagable
{
    [SerializeField] private GameObject _weaponPlacement;

    protected float MaxHealth;

    protected float CurrentHealth;
    protected float BaseDamage;
    protected float BaseAttackSpeed;

    protected IDamagable CurrentTarget;
    protected IWeapon CurrentWeapon;

    public UnityAction<float, float> HealthChanged;
    public UnityAction Died;

    public override void SetData(CharacterData data)
    {
        base.SetData(data);

        var characterData = data as FighterData;

        MaxHealth = characterData.BaseHealth;
        SetHealth(MaxHealth);
        HealthChanged?.Invoke(CurrentHealth, MaxHealth);

        BaseDamage = characterData.BaseAttackDamage;
        BaseAttackSpeed = characterData.BaseAttackDelay;
    }

    private void Update()
    {
        RotateToTarget();
        Attack();
    }

    protected virtual void RotateToTarget()
    {
        if (!TargetIsActive())
            return;

        if (Movable.IsMoving())
            return;

        Vector3 directionToTarget = ((MonoBehaviour)CurrentTarget).transform.position - transform.position;

        directionToTarget.y = 0;

        if (directionToTarget == Vector3.zero)
            return;

        Movable.Rotate(directionToTarget);
    }

    public void SetWeapon(IWeapon weapon)
    {
        CurrentWeapon = weapon;
    }

    public void SetTarget(IDamagable target)
    {
        CurrentTarget = target;
    }

    public virtual void Attack()
    {
        if (!TargetIsActive())
            return;

        if (Movable.IsMoving())
            return;

        CurrentWeapon?.Attack(CurrentTarget);
    }

    public GameObject GetWeaponPlacement()
    {
        return _weaponPlacement;
    }

    public Vector3 GetCurrentDirection()
    {
        return transform.forward;
    }

    public void TakeDamage(float value)
    {
        if (value < 0)
            return;

        CurrentHealth -= value;

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            Die();
        }

        HealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    private void SetHealth(float value)
    {
        CurrentHealth = value;
        HealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    protected virtual void Die()
    {
        Died?.Invoke();
    }

    protected bool TargetIsActive()
    {
        bool targetIsNull = (CurrentTarget == null || ((MonoBehaviour)CurrentTarget) == null);

        if (targetIsNull)
            CurrentTarget = null;

        return !targetIsNull;
    }

    public abstract float CalculateTotalDamage();
    public abstract float CalculateTotalAttackDelay();
}