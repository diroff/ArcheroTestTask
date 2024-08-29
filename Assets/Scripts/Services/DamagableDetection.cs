using System.Collections.Generic;
using UnityEngine;

public class DamagableDetection : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;

    private List<IDamagable> _damagablesInRange = new List<IDamagable>();

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable == null || other.gameObject == _fighter.gameObject)
            return;

        if (_damagablesInRange.Contains(damagable))
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
        RemoveNullObjectsFromList();

        if (_damagablesInRange.Count == 0)
        {
            ClearTarget();
            return;
        }

        IDamagable closestDamagable = FindClosestDamagable();
        _fighter.SetTarget(closestDamagable);
    }

    private void RemoveNullObjectsFromList()
    {
        _damagablesInRange.RemoveAll(damagable => damagable == null || !(damagable is MonoBehaviour));
    }

    private IDamagable FindClosestDamagable()
    {
        IDamagable closestDamagable = null;
        float closestDistance = float.MaxValue;

        foreach (var damagable in _damagablesInRange)
        {
            if (damagable is MonoBehaviour monoBehaviour)
            {
                if (monoBehaviour == null || monoBehaviour.transform == null)
                    continue;

                float distance = Vector3.Distance(transform.position, monoBehaviour.transform.position);

                if (distance >= closestDistance)
                    continue;

                closestDistance = distance;
                closestDamagable = damagable;
            }
        }

        return closestDamagable;
    }

    private void ClearTarget()
    {
        _fighter.SetTarget(null);
    }
}