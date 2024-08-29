using UnityEngine;

public class WeaponData : ScriptableObject
{
    [field: SerializeField] public float BaseAttackSpeed { get; private set; }
    [field: SerializeField] public float BaseAttackDamage { get; private set; }
}
