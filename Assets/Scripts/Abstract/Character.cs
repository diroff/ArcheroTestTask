using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    protected CharacterData _data;

    protected float _currentSpeed;

    private IMovable _movable;

    public UnityAction<float> SpeedChanged;

    public void SetMovableStrategy(IMovable movable)
    {
        _movable = movable;
    }

    public void Move(Vector3 direction)
    {
        _movable?.Move(direction);
    }

    public void SetData(CharacterData data)
    {
        _data = data;
    }

    public void IncreaseSpeed(float value)
    {
        if (value < 0)
            return;

        _currentSpeed += value;
        SpeedChanged?.Invoke(_currentSpeed);
    }

    public void DecreaseSpeed(float value)
    {
        if (value < 0)
            return;

        _currentSpeed -= value;
        SpeedChanged?.Invoke(_currentSpeed);
    }
}