using UnityEngine;

public class RandomMovementTester : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _patrolRadius = 3f;
    [SerializeField] private float _minChangeDirectionInterval = 2f;
    [SerializeField] private float _maxChangeDirectionInterval = 5f;
    [SerializeField] private float _arrivalThreshold = 0.5f;

    private Vector3 _currentTargetPosition;
    private float _timeSinceLastDirectionChange;
    private float _currentChangeDirectionInterval;
    private bool _isWaiting;

    private void Start()
    {
        _fighter.SetMovableStrategy(new RigidbodyMovement(_rigidbody, _fighter.CurrentSpeed));

        SetNewPatrolTarget();
    }

    private void FixedUpdate()
    {
        if (_isWaiting)
        {
            _timeSinceLastDirectionChange += Time.fixedDeltaTime;
            if (_timeSinceLastDirectionChange >= _currentChangeDirectionInterval)
            {
                _isWaiting = false;
                SetNewPatrolTarget();
            }
            return;
        }

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 directionToTarget = (_currentTargetPosition - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, _currentTargetPosition);

        if (distanceToTarget > _arrivalThreshold)
            _fighter.Move(directionToTarget);
        else
            StartWaiting();
    }

    private void StartWaiting()
    {
        _isWaiting = true;
        _timeSinceLastDirectionChange = 0f;
        _currentChangeDirectionInterval = Random.Range(_minChangeDirectionInterval, _maxChangeDirectionInterval);
    }

    private void SetNewPatrolTarget()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _patrolRadius;
        _currentTargetPosition = new Vector3(randomPoint.x, transform.position.y, randomPoint.y);
    }
}
