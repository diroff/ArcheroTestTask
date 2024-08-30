using UnityEngine;

public class LevelEnemies : MonoBehaviour
{
    [SerializeField] private LevelEnemiesData _enemiesSetting;
    [SerializeField] private LevelGenerator _levelGenerator;

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
    }

    private void SpawnEnemy()
    {
        var spawnPoint = _levelGenerator.GetSpawnPointForEnemy();
        var data = GetData();

        var enemy = Instantiate(GetEnemyToSpawn(), spawnPoint, Quaternion.identity);
        enemy.SetData(data);
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