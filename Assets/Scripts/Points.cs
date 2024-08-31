using UnityEngine;
using UnityEngine.Events;

public class Points : MonoBehaviour
{
    private int _currentPoints;

    public UnityAction<int> PointsCountChanged;

    public void AddPoints(int count)
    {
        if (count < 0)
            return;

        _currentPoints += count;

        PointsCountChanged?.Invoke(_currentPoints);
        Debug.Log($"Current points: {_currentPoints}");
    }
}