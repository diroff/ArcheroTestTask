using UnityEngine;

public abstract class Movement : IMovable
{
    protected float Speed;

    public Movement(float speed)
    {
        Speed = speed;
    }

    public abstract void Move(Vector3 position);
    public abstract void Rotate(Vector3 rotation);
    public abstract bool IsMoving();
}
