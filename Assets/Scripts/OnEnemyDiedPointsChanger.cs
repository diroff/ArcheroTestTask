using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDiedPointsChanger : MonoBehaviour
{
    [SerializeField] private LevelEnemiesSpawner _enemiesSpawner;
    [SerializeField] private Points _points;

    private List<Enemy> _levelEnemies;

    private void OnEnable()
    {
        _enemiesSpawner.EnemiesSpawned += OnEnemiesSpawned;
    }

    private void OnDisable()
    {
        _enemiesSpawner.EnemiesSpawned -= OnEnemiesSpawned;

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
        _points.AddPoints(1);
    }
}