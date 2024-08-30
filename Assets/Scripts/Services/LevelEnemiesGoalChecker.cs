using System.Collections.Generic;
using UnityEngine;

public class LevelEnemiesGoalChecker : LevelGoalChecker
{
    [SerializeField] private LevelEnemiesSpawner _enemies;

    private int _destroyedEnemyCount;

    private List<Enemy> _levelEnemies;

    private void OnEnable()
    {
        _enemies.EnemiesSpawned += OnEnemiesSpawned;
    }

    private void OnDisable()
    {
        _enemies.EnemiesSpawned -= OnEnemiesSpawned;

        if (_levelEnemies == null)
            return;

        foreach (var enemy in _levelEnemies)
            enemy.Died -= OnEnemyDied;
    }

    private void OnEnemiesSpawned(List<Enemy> enemies)
    {
        _levelEnemies = enemies;

        foreach (var enemy in _levelEnemies)
            enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        _destroyedEnemyCount++;

        Debug.Log($"Destroyed enemies: {_destroyedEnemyCount}/{_levelEnemies.Count}");

        if (IsLevelCompleted())
            CompleteLevel();
    }

    protected override void CompleteLevel()
    {
        foreach (var enemy in _levelEnemies)
            enemy.Died -= OnEnemyDied;

        base.CompleteLevel();
    }

    private bool IsLevelCompleted()
    {
        return _destroyedEnemyCount >= _levelEnemies.Count;
    }
}