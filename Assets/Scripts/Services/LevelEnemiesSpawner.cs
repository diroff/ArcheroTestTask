using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelEnemiesSpawner : MonoBehaviour
{
    [SerializeField] private LevelEnemiesData _enemiesSetting;
    [SerializeField] private LevelGenerator _levelGenerator;

    private List<Enemy> _currentEnemies = new List<Enemy>();

    public UnityAction<List<Enemy>> EnemiesSpawned;

    private void OnEnable()
    {
        _levelGenerator.LevelCreated += OnLevelCreated;
    }

    private void OnDisable()
    {
        _levelGenerator.LevelCreated -= OnLevelCreated;
    }

    private void OnLevelCreated()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var count = _enemiesSetting.EnemiesCount;

        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
        }

        EnemiesSpawned?.Invoke(_currentEnemies);
    }

    private void SpawnEnemy()
    {
        var spawnPoint = _levelGenerator.GetSpawnPointForEnemy();
        var data = GetData();

        var enemy = Instantiate(GetEnemyToSpawn(), spawnPoint, Quaternion.identity);
        enemy.SetData(data);

        _currentEnemies.Add(enemy);
    }

    private Enemy GetEnemyToSpawn()
    {
        int enemyNumber = Random.Range(0, _enemiesSetting.EnemyPrefabs.Count);

        return _enemiesSetting.EnemyPrefabs[enemyNumber];
    }

    private EnemyData GetData()
    {
        int enemyNumber = Random.Range(0, _enemiesSetting.EnemyDatas.Count);

        return _enemiesSetting.EnemyDatas[enemyNumber];
    }
}