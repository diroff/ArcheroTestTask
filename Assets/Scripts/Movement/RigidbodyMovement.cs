using UnityEngine;

public class RigidbodyMovement : Movement
{
    protected Rigidbody Rigidbody;

    public RigidbodyMovement(Rigidbody rigidbody, float speed) : base(speed)
    {
        Rigidbody = rigidbody;
    }

    public override void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
            StopMovement();
        else
        {
            ApplyMovement(direction);
            Rotate(direction);
        }
    }

    protected void ApplyMovement(Vector3 direction)
    {
        Rigidbody.velocity = direction.normalized * Speed;
    }

    public override void Rotate(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition.normalized;

        if (direction == Vector3.zero)
            return; 

        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        Rigidbody.rotation = Quaternion.Slerp(Rigidbody.rotation, targetRotation, 10 * Time.deltaTime);
    }

    public override bool IsMoving()
    {
        return Rigidbody.velocity != Vector3.zero;
    }

    private void StopMovement()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
    }
}