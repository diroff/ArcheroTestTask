using UnityEngine;

public class FighterData : CharacterData
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float BaseHealth { get; private set; }
    [field: SerializeField] public float BaseAttackSpeed { get; private set; }
    [field: SerializeField] public float BaseAttackDamage { get; private set; }
}