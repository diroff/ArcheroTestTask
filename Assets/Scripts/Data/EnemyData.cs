using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Create Data/Character Data/New Enemy Data", order = 51)]
public class EnemyData : FighterData
{
    [field: SerializeField] public float MovementRange { get; private set; }
    [field: SerializeField] public float ImmobilityTime { get; private set; }
}