using System.Collections;
using UnityEngine;

public class LevelStartDelay : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;

    [SerializeField] private float _delayInSeconds = 3.0f;

    private void OnEnable()
    {
        _levelGenerator.LevelCreated += OnLevelCreated;
    }

    private void OnDisable()
    {
        _levelGenerator.LevelCreated -= OnLevelCreated;
    }

    private void OnLevelCreated()
    {
        StopTime();
    }

    private void StopTime()
    {
        Debug.Log($"{_delayInSeconds} freeze...");
        Time.timeScale = 0;
        StartCoroutine(StartGameAfterDelay(_delayInSeconds));
    }

    private IEnumerator StartGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1;
        Debug.Log("Game continues");
    }
}