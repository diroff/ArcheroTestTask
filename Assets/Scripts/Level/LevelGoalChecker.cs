using UnityEngine;
using UnityEngine.Events;

public abstract class LevelGoalChecker : MonoBehaviour
{
    public UnityAction LevelGoalAchived;

    protected virtual void CompleteLevel()
    {
        LevelGoalAchived?.Invoke();
    }
}