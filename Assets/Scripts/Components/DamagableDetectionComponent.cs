using UnityEngine;

public class DamagableDetectionComponent : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;

    private float _detectionRadius;
    private IDamagable currentTarget;

    private void Start()
    {
        _detectionRadius = _fighter.ReturnTargetZoneDetection();
    }

    private void Update()
    {
        DetectTargets();
    }

    private void DetectTargets()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        float closestDistanceSqr = Mathf.Infinity;
        IDamagable closestTarget = null;

        Vector3 originPosition = transform.position;

        foreach (var hitCollider in hitColliders)
        {
            if (IsIgnoredByCurrentFighter(hitCollider))
                continue;

            IDamagable damagable = hitCollider.GetComponent<IDamagable>();

            if (damagable == null)
                continue;

            Vector3 targetPosition = hitCollider.transform.position;
            float distanceSqr = (targetPosition - originPosition).sqrMagnitude;

            if (distanceSqr < closestDistanceSqr)
            {
                closestDistanceSqr = distanceSqr;
                closestTarget = damagable;
            }
        }

        SetTarget(closestTarget);
    }

    private bool IsIgnoredByCurrentFighter(Collider hitCollider)
    {
        string currentFighterTag = _fighter.CompareTag("Player") ? "Player" : "Enemy";
        return hitCollider.CompareTag(currentFighterTag);
    }

    private void SetTarget(IDamagable target)
    {
        if (_fighter == null)
            return;

        if (target != currentTarget)
        {
            currentTarget = target;
            _fighter.SetTarget(currentTarget);
        }
    }
}