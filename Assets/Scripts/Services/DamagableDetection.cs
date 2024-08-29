using System.Collections.Generic;
using UnityEngine;

public class DamagableDetection : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;

    private List<IDamagable> _damagablesInRange = new List<IDamagable>();

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable == null)
            return;

        if (other.gameObject == _fighter.gameObject)
            return;

        _damagablesInRange.Add(damagable);
        UpdateTarget();
    }

    private void OnTriggerExit(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable == null)
            return;

        if (!_damagablesInRange.Contains(damagable))
            return;

        _damagablesInRange.Remove(damagable);
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (_damagablesInRange.Count == 0)
        {
            ClearTarget();
            return;
        }

        IDamagable closestDamagable = FindClosestDamagable();
        _fighter.SetTarget(closestDamagable);
    }

    private void ClearTarget()
    {
        _fighter.SetTarget(null);
    }

    private IDamagable FindClosestDamagable()
    {
        IDamagable closestDamagable = null;
        float closestDistance = float.MaxValue;

        foreach (var damagable in _damagablesInRange)
        {
            float distance = CalculateDistance(damagable);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestDamagable = damagable;
            }
        }

        return closestDamagable;
    }

    private float CalculateDistance(IDamagable damagable)
    {
        return Vector3.Distance(transform.position, ((MonoBehaviour)damagable).transform.position);
    }
}