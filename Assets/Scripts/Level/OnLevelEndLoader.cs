using UnityEngine;

public class OnLevelEndLoader : MonoBehaviour
{
    [SerializeField] private OnLevelEndedDoorOpener _doorOpener;
    [SerializeField] private LevelLoading _levelLoading;

    private Door _door;

    private void OnEnable()
    {
        _doorOpener.DoorWasSetted += OnDoorWasSetted;

        if (_door == null)
            return;

        _door.WasUsed += OnDoorWasUsed;
    }

    private void OnDisable()
    {
        _doorOpener.DoorWasSetted -= OnDoorWasSetted;

        if (_door == null)
            return;

        _door.WasUsed -= OnDoorWasUsed;
    }

    private void OnDoorWasSetted(Door door)
    {
        _door = door;
        _door.WasUsed += OnDoorWasUsed;
    }

    private void OnDoorWasUsed()
    {
        _door.WasUsed -= OnDoorWasUsed;

        _levelLoading.LoadLevel();
    }
}