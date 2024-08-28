using UnityEngine.Events;

public abstract class Fighter : Character, IDamagable, IAttacker
{
    protected float MaxHealth;

    protected float CurrentHealth;
    protected float BaseDamage;
    protected float BaseAttackSpeed;

    private IDamagable _currentTarget;

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
        BaseAttackSpeed = characterData.BaseAttackSpeed;
    }

    public void Attack(IDamagable target)
    {
        _currentTarget = target;

        _currentTarget?.TakeDamage(CalculateTotalDamage());
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

    public abstract float CalculateTotalDamage();
    public abstract float CalculateTotalAttackSpeed();
}