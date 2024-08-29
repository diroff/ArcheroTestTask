using UnityEngine;

public class WeaponData : ScriptableObject
{
    [field: SerializeField] public float BaseAttackDelay { get; private set; }
    [field: SerializeField] public float BaseAttackDamage { get; private set; }
}
