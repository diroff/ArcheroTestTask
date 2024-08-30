using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private Player _player;
    private Vector3 _direction;

    private void OnEnable()
    {
        _playerSpawner.PlayerWasCreated += OnPlayerCreated;
    }

    private void OnDisable()
    {
        _playerSpawner.PlayerWasCreated -= OnPlayerCreated;
    }

    private void OnPlayerCreated(Player player)
    {
        _player = player;
    }

    private void Move(Vector3 direction)
    {
        _player?.Move(direction);
    }

    private void Update()
    {
        var horizontal = _joystick.Horizontal;
        var vertical = _joystick.Vertical;

        _direction = new Vector3(horizontal, 0, vertical);
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }
}