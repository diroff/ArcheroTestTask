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
        Debug.Log("Move Towards Target");
        Vector3 direction = ((MonoBehaviour)CurrentTarget).transform.position - transform.position;

        Move(direction);
    }
}