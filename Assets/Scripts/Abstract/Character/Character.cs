using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    protected CharacterData Data;

    protected float CurrentSpeed;

    protected IMovable Movable;

    public UnityAction<float> SpeedChanged;

    public virtual void SetData(CharacterData data)
    {
        Data = data;

        IncreaseSpeed(Data.BaseSpeed);
    }

    public void SetMovableStrategy(IMovable movable)
    {
        Movable = movable;
    }

    public void Move(Vector3 direction)
    {
        Movable?.Move(direction);
    }

    public void IncreaseSpeed(float value)
    {
        if (value < 0)
            return;

        CurrentSpeed += value;
        SpeedChanged?.Invoke(CurrentSpeed);
    }

    public void DecreaseSpeed(float value)
    {
        if (value < 0)
            return;

        CurrentSpeed -= value;
        SpeedChanged?.Invoke(CurrentSpeed);
    }
}