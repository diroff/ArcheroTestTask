using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementTester : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    private IMovable _movable;

    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        CreateRigidbodyMovement();
    }

    private void CreateRigidbodyMovement()
    {
        _movable = new GroundMovement(_rigidbody, _speed);
    }

    private void Move(Vector3 direction)
    {
        _movable?.Move(direction);
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move(new Vector3(_horizontal, 0, _vertical));
    }
}