using System.Collections.Generic;
using UnityEngine;

public class FighterCreatorTester : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;

    [SerializeField] private List<EnemyData> _enemyDatas;
    [SerializeField] private List<Enemy> _enemyPrefabs;

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Player _playerPrefab;

    private List<Enemy> _createdEnemies = new List<Enemy>();

    private Player _player;

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
        CreatePlayer(_levelGenerator.GetSpawnPointForPlayer());
    }

    private void CreatePlayer(Vector3 spawnPoint)
    {
        _player = Instantiate(_playerPrefab, spawnPoint, Quaternion.identity);

        _player.SetData(_playerData);
    }

    private void CreateEnemy(Vector3 spawnPoint)
    {
        var enemyNumber = Random.Range(0, _enemyDatas.Count);
        var enemy = Instantiate(GetRandomEnemy(), spawnPoint, Quaternion.identity);
        enemy.SetData(_enemyDatas[enemyNumber]);

        _createdEnemies.Add(enemy);
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public Enemy GetRandomEnemy()
    {
        if (_enemyPrefabs.Count == 0)
            return null;

        int enemyNumber = Random.Range(0, _enemyPrefabs.Count);

        return _enemyPrefabs[enemyNumber];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CreateEnemy(_levelGenerator.GetSpawnPointForEnemy());
    }
}