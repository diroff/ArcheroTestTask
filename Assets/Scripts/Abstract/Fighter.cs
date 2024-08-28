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

        }

        HealthChanged?.Invoke(CurrentHealth, BaseHealth);
    }

    public abstract float CalculateTotalDamage();
    public abstract float CalculateTotalAttackSpeed();
}