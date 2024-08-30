using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void AttackStrategy()
    {
        if (!TargetIsActive())
            return;

        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        if (CurrentTarget == null)
            return;

        Vector3 direction = ((MonoBehaviour)CurrentTarget).transform.position - transform.position;
        direction.y = 0;

        Move(direction);
    }
}