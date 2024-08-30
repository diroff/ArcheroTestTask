using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Create Data/Level Data/Level Generation Settins Data", order = 51)]
public class LevelGenerationSettingsData : ScriptableObject
{
    [field: SerializeField] public int HorizontalSize { get; private set; }
    [field: SerializeField] public int VerticalSize { get; private set; }

    [field: SerializeField] public int ObstacleWallsCount { get; private set; }
    [field: SerializeField] public int ObstacleHoleCount { get; private set; }
}
