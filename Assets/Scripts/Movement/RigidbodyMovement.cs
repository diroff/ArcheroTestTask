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
        RotateTowards(position);
    }

    protected void ApplyMovement(Vector3 position)
    {
        Rigidbody.velocity = position * Speed;
    }

    protected void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition.normalized;

        if (direction == Vector3.zero)
            return; 

        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        Rigidbody.rotation = Quaternion.Slerp(Rigidbody.rotation, targetRotation, 10 * Time.deltaTime);
    }
}