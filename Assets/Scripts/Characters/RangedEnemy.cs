public class RangedEnemy : Enemy
{
    public override void AttackStrategy()
    {
        if (!TargetIsActive())
            return;

        Attack();
    }
}