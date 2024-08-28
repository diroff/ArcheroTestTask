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

    private Queue<Enemy> _createdEnemies = new Queue<Enemy>();

    public void CreatePlayer()
    {
        var player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);

        player.SetData(_playerData);
    }

    public void CreateEnemy()
    {
        var enemyNumber = Random.Range(0, _enemyDatas.Count);

        var enemy = Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
        enemy.SetData(_enemyDatas[enemyNumber]);
        _createdEnemies.Enqueue(enemy);
    }

    private void DestroyLastEnemy()
    {
        if (_createdEnemies.Count == 0)
            return;

        var enemy = _createdEnemies.Dequeue();
        Destroy(enemy.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
            CreatePlayer();

        if (Input.GetKeyDown(KeyCode.E))
            CreateEnemy();

        if (Input.GetKeyDown(KeyCode.D))
            DestroyLastEnemy();
    }
}