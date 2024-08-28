using UnityEngine;

public class FightTester : MonoBehaviour
{
    [SerializeField] private FighterCreatorTester _fighterCreator;

    private Player _player;
    private Enemy _enemy;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            AttackEnemy();

        if (Input.GetMouseButtonDown(1))
            AttackPlayer();
    }

    public void AttackPlayer()
    {
        if (!TryToPrepareTargetsToAttack())
            return;

        _enemy.Attack(_player);
    }

    public void AttackEnemy()
    {
        if (!TryToPrepareTargetsToAttack())
            return;

        _player.Attack(_enemy);
    }

    private bool TryToPrepareTargetsToAttack()
    {
        _player = _fighterCreator.GetPlayer();
        _enemy = _fighterCreator.GetRandomEnemy();

        if (_enemy == null || _player == null)
            return false;

        return true;
    }
}