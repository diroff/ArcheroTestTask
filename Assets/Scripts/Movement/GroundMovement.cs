using UnityEngine;

public class GroundMovement : RigidbodyMovement
{
    public GroundMovement(Rigidbody rigidbody, float speed) : base(rigidbody, speed) { }

    public override void Move(Vector3 position)
    {
        position = new Vector3(position.x, 0, position.z);

        base.Move(position);
    }
}