using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private int _levelWidth = 10;
    [SerializeField] private int _levelHeight = 10;

    [Header("Prefabs")]
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _doorPrefab;

    [Header("Obstacle Settings")]
    [SerializeField] private int _numberOfObstacles = 5;

    private Vector3 _levelCenter;

    private void SetLevelCenter()
    {
        _levelCenter = new Vector3(_levelWidth / 2f, 0, _levelHeight / 2f);
    }

    private void Start()
    {
        SetLevelCenter();
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        CreateFloor();
        CreateWalls();
        CreateObstacles();
        CreateDoor();
    }

    private void CreateFloor()
    {
        for (int x = 0; x < _levelWidth; x++)
        {
            for (int y = 0; y < _levelHeight; y++)
            {
                Vector3 position = new Vector3(x, 0, y) - _levelCenter;
                Instantiate(_floorPrefab, position, Quaternion.identity, transform);
            }
        }
    }

    private void CreateWalls()
    {
        for (int x = -1; x <= _levelWidth; x++)
        {
            Instantiate(_wallPrefab, new Vector3(x, 0, -1) - _levelCenter, Quaternion.identity, transform);
            Instantiate(_wallPrefab, new Vector3(x, 0, _levelHeight) - _levelCenter, Quaternion.identity, transform);
        }

        for (int y = 0; y < _levelHeight; y++)
        {
            Instantiate(_wallPrefab, new Vector3(-1, 0, y) - _levelCenter, Quaternion.identity, transform);
            Instantiate(_wallPrefab, new Vector3(_levelWidth, 0, y) - _levelCenter, Quaternion.identity, transform);
        }
    }

    private void CreateObstacles()
    {
        for (int i = 0; i < _numberOfObstacles; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, _levelWidth), 0, Random.Range(0, _levelHeight)) - _levelCenter;
            Instantiate(_obstaclePrefab, position, Quaternion.identity, transform);
        }
    }

    private void CreateDoor()
    {
        Vector3 position = new Vector3(_levelWidth / 2f, 0, _levelHeight) - _levelCenter;
        Instantiate(_doorPrefab, position, Quaternion.identity, transform);
    }
}