using UnityEngine;

public class RigidbodyMovement : Movement
{
    protected Rigidbody Rigidbody;

    public RigidbodyMovement(Rigidbody rigidbody, float speed) : base(speed)
    {
        Rigidbody = rigidbody;
    }

    public override void Move(Vector3 position)
    {
        ApplyMovement(position);
    }

    protected void ApplyMovement(Vector3 position)
    {
        Rigidbody.MovePosition(position);
    }
}