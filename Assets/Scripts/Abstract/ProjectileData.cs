using UnityEngine;

public class ProjectileData : ScriptableObject
{
    [field: SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public float BaseSpeed { get; private set; }

    [field: SerializeField] public float LifeTime { get; private set; }
}