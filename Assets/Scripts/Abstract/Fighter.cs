using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Fighter : Character, IDamagable, IAttacker
{
    protected float BaseHealth;

    protected float CurrentHealth;
    protected float BaseDamage;
    protected float BaseAttackSpeed;

    private IDamagable _currentTarget;

    public UnityAction<float, float> HealthChanged;
    public UnityAction Died;

    public void Attack(IDamagable target)
    {
        _currentTarget?.TakeDamage(CalculateTotalDamage());
    }

    public void TakeDamage(float value)
    {
        if (value < 0)
            return;

        CurrentHealth -= value;

        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
            Die();
        }

        HealthChanged?.Invoke(CurrentHealth, BaseHealth);
    }

    protected virtual void Die()
    {
        Died?.Invoke();
    }

    public abstract float CalculateTotalDamage();
    public abstract float CalculateTotalAttackSpeed();
}