using UnityEngine;

public class SimplePatrol : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _startPosition;

    private void Start()
    {
        _fighter.SetMovableStrategy(new RigidbodyMovement(_rigidbody, _fighter.CurrentSpeed));
    }
}