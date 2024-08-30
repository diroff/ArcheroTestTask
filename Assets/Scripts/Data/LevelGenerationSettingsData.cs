using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Create Data/Level Data/Level Generation Settins Data", order = 51)]
public class LevelGenerationSettingsData : ScriptableObject
{
    [field: SerializeField, Range(2, 99)] public int HorizontalSize { get; private set; }
    [field: SerializeField, Range(2, 99)] public int VerticalSize { get; private set; }

    [field: SerializeField] public int ObstacleWallsCount { get; private set; }
    [field: SerializeField] public int ObstacleHoleCount { get; private set; }
}
