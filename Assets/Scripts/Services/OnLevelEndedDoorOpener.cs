using UnityEngine;

public class OnLevelEndedDoorOpener : MonoBehaviour
{
    [SerializeField] private LevelGoalChecker _levelGoalChecker;
    [SerializeField] private LevelGenerator _levelGenerator;

    private Door _door;

    private void OnEnable()
    {
        _levelGenerator.LevelCreated += OnLevelCreated;
        _levelGoalChecker.LevelGoalAchived += OnLevelGoalAchived;
    }

    private void OnDisable()
    {
        _levelGenerator.LevelCreated -= OnLevelCreated;
        _levelGoalChecker.LevelGoalAchived -= OnLevelGoalAchived;
    }

    private void OnLevelCreated()
    {
        _door = _levelGenerator.GetDoor();
    }

    private void OnLevelGoalAchived()
    {
        _door.OpenDoor();
    }
}