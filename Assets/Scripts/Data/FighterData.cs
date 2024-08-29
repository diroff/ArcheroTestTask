using UnityEngine;

public class FighterData : CharacterData
{
    [field: SerializeField] public float BaseHealth { get; private set; }
    [field: SerializeField] public float BaseAttackDelay { get; private set; }
    [field: SerializeField] public float BaseAttackDamage { get; private set; }
}