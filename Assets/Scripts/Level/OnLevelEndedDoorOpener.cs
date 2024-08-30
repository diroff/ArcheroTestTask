using UnityEngine;
using UnityEngine.Events;

public class OnLevelEndedDoorOpener : MonoBehaviour
{
    [SerializeField] private LevelGoalChecker _levelGoalChecker;
    [SerializeField] private LevelGenerator _levelGenerator;

    private Door _door;

    public UnityAction<Door> DoorWasSetted;

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
        DoorWasSetted?.Invoke(_door);
    }

    private void OnLevelGoalAchived()
    {
        _door.OpenDoor();
    }
}