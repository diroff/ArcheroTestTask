using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelEnemiesData", menuName = "Create Data/Level Data/Level Enemies Data", order = 51)]
public class LevelEnemiesData : ScriptableObject
{
    [field: SerializeField, Min(0)] public int EnemiesCount { get; private set; }

    [field: SerializeField] public List<Enemy> EnemyPrefabs { get; private set; }
    [field: SerializeField] public List<EnemyData> EnemyDatas { get; private set; }
}