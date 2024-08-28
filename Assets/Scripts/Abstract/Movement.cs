using UnityEngine;

public abstract class Movement : IMovable
{
    protected float _speed;

    public Movement(float speed)
    {
        _speed = speed;
    }

    public void Move(Vector3 position) { }
}
