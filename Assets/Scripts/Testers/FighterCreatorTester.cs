using System.Collections.Generic;
using UnityEngine;

public class FighterCreatorTester : MonoBehaviour
{
    [SerializeField] private List<EnemyData> _enemyDatas;
    [SerializeField] private List<Enemy> _enemyPrefabs;

    [SerializeField] private PlayerData _playerData;

    [SerializeField] private Player _playerPrefab;

    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;

    private List<Enemy> _createdEnemies = new List<Enemy>();

    private Player _player;

    private void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);

        _player.SetData(_playerData);
    }

    private void CreateEnemy()
    {
        var enemyNumber = Random.Range(0, _enemyDatas.Count);

        Vector3 spawnDimention = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));

        var enemy = Instantiate(GetRandomEnemy(), _enemySpawnPoint.position + spawnDimention, Quaternion.identity);
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
            CreateEnemy();
    }
}