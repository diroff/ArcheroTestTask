using UnityEngine;

public class FlyingMovement : RigidbodyMovement
{
    private const float FlyingHeight = 1f;

    public FlyingMovement(Rigidbody rigidbody, float speed) : base(rigidbody, speed) { }

    public override void Move(Vector3 direction)
    {
        direction = new Vector3(direction.x, direction.y + FlyingHeight, direction.z);
        base.Move(direction);
    }
}