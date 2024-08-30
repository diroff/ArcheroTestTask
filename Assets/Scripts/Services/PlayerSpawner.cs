using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private LevelGenerator _levelGenerator;

    private Player _player;

    public UnityAction<Player> PlayerWasCreated;

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
        PlayerWasCreated?.Invoke(_player);
    }
}