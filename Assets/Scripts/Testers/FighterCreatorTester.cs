using System.Collections.Generic;
using UnityEngine;

public class FighterCreatorTester : MonoBehaviour
{
    [SerializeField] private List<EnemyData> _enemyDatas;
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;

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

        var enemy = Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
        enemy.SetData(_enemyDatas[enemyNumber]);
        _createdEnemies.Add(enemy);
    }

    private void DestroyLastEnemy()
    {
        if (_createdEnemies.Count == 0)
            return;

        var enemy = _createdEnemies[_createdEnemies.Count - 1];

        _createdEnemies.RemoveAt(_createdEnemies.Count - 1);
        Destroy(enemy.gameObject);
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public Enemy GetRandomEnemy()
    {
        if (_createdEnemies.Count == 0)
            return null;

        int enemyNumber = Random.Range(0, _createdEnemies.Count);

        return _createdEnemies[enemyNumber];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CreateEnemy();

        if (Input.GetKeyDown(KeyCode.D))
            DestroyLastEnemy();
    }
}