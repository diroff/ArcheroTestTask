using System.Collections;
using UnityEngine;

public class DamageClosestObjectsComponent : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private float _damageRadius = 5f;

    private float _damageInterval;

    private void Start()
    {
        _damageInterval = _fighter.CalculateTotalAttackDelay();
        StartCoroutine(ApplyDamageOverTime());
    }

    private IEnumerator ApplyDamageOverTime()
    {
        while (isActiveAndEnabled)
        {
            ApplyDamageToNearbyObjects();
            yield return new WaitForSeconds(_damageInterval);
        }
    }

    private void ApplyDamageToNearbyObjects()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _damageRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (IsIgnoredByCurrentFighter(hitCollider))
                continue;

            IDamagable damagable = hitCollider.GetComponent<IDamagable>();

            if (damagable == null)
                continue;

            damagable.TakeDamage(_fighter.CalculateTotalDamage());
        }
    }

    private bool IsIgnoredByCurrentFighter(Collider hitCollider)
    {
        Fighter hitFighter = hitCollider.GetComponent<Fighter>();

        if (hitFighter != null)
        {
            string currentFighterTag = _fighter.CompareTag("Player") ? "Player" : "Enemy";
            return hitFighter.CompareTag(currentFighterTag);
        }

        return false;
    }
}
