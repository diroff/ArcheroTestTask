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
        Vector3 direction = ((MonoBehaviour)CurrentTarget).transform.position - transform.position;

        Move(direction);
    }
}