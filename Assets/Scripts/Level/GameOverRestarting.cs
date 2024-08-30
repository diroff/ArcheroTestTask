using UnityEngine;

public class GameOverRestarting : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private LevelLoading _levelLoading;

    private Player _player;

    private void OnEnable()
    {
        _spawner.PlayerWasCreated += OnPlayerWasCreated;

        if (_player == null)
            return;

        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _spawner.PlayerWasCreated -= OnPlayerWasCreated;

        if (_player == null)
            return;

        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerWasCreated(Player player)
    {
        _player = player;
        _player.Died += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _player.Died -= OnPlayerDied;
        _levelLoading.Restart();
    }
}