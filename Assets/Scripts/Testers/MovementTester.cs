using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementTester : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Rigidbody _rigidbody;

    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        CreateRigidbodyMovement();
    }

    private void CreateRigidbodyMovement()
    {
        _fighter.SetMovableStrategy(new GroundMovement(_rigidbody, _fighter.CurrentSpeed));
    }

    private void Move(Vector3 direction)
    {
        _fighter.Move(direction);
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