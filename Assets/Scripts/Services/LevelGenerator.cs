using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private LevelGenerationSettingsData _levelSettings;

    [Header("Prefabs")]
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _doorPrefab;
    [SerializeField] private GameObject _obstacleWallPrefab;
    [SerializeField] private GameObject _obstacleHolePrefab;

    private int _levelWidth;
    private int _levelHeight;

    private int _obstacleWallsCount;
    private int _obstacleHoleCount;

    private Vector3 _levelCenter;

    private float _wallHeight;

    private void Awake()
    {
        SetLevelSettings();
    }

    private void Start()
    {
        SetLevelCenter();
        _wallHeight = _wallPrefab.GetComponent<Renderer>().bounds.size.y;
        GenerateLevel();
    }

    private void SetLevelSettings()
    {
        _levelWidth = _levelSettings.HorizontalSize;
        _levelHeight = _levelSettings.VerticalSize;

        _obstacleWallsCount = _levelSettings.ObstacleWallsCount;
        _obstacleHoleCount = _levelSettings.ObstacleHoleCount;
    }

    private void GenerateLevel()
    {
        CreateFloor();
        CreateWalls();
        CreateWallObstacles();
        CreateHoleObstacles();
        CreateDoor();
    }

    private void SetLevelCenter()
    {
        _levelCenter = new Vector3(_levelWidth / 2f, 0, _levelHeight / 2f);
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
            Instantiate(_wallPrefab, new Vector3(x, _wallHeight / 2f, -1) - _levelCenter, Quaternion.identity, transform);
            Instantiate(_wallPrefab, new Vector3(x, _wallHeight / 2f, _levelHeight) - _levelCenter, Quaternion.identity, transform);
        }

        for (int y = 0; y < _levelHeight; y++)
        {
            Instantiate(_wallPrefab, new Vector3(-1, _wallHeight / 2f, y) - _levelCenter, Quaternion.identity, transform);
            Instantiate(_wallPrefab, new Vector3(_levelWidth, _wallHeight / 2f, y) - _levelCenter, Quaternion.identity, transform);
        }
    }

    private void CreateWallObstacles()
    {
        for (int i = 0; i < _obstacleWallsCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, _levelWidth), _wallHeight / 2f, Random.Range(0, _levelHeight)) - _levelCenter;
            Instantiate(_obstacleWallPrefab, position, Quaternion.identity, transform);
        }
    }

    private void CreateHoleObstacles()
    {
        for (int i = 0; i < _obstacleHoleCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, _levelWidth), 0, Random.Range(0, _levelHeight)) - _levelCenter;
            Instantiate(_obstacleHolePrefab, position, Quaternion.identity, transform);
        }
    }

    private void CreateDoor()
    {
        Vector3 position = new Vector3(_levelWidth / 2f, _wallHeight / 2f, _levelHeight) - _levelCenter;
        Instantiate(_doorPrefab, position, Quaternion.identity, transform);
    }
}