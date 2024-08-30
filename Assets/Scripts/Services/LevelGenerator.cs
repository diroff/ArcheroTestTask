using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private LevelGenerationSettingsData _levelSettings;

    [Header("Prefabs")]
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private Door _doorPrefab;
    [SerializeField] private GameObject _obstacleWallPrefab;
    [SerializeField] private GameObject _obstacleHolePrefab;

    private int _levelWidth;
    private int _levelHeight;

    private int _obstacleWallsCount;
    private int _obstacleHoleCount;

    private Vector3 _levelCenter;
    private float _wallHeight;
    private List<Vector3> _availableFloorPositions;
    private HashSet<Vector3> _occupiedPositions;

    private Door _door;

    public UnityAction LevelCreated;

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
        _availableFloorPositions = new List<Vector3>();
        _occupiedPositions = new HashSet<Vector3>();

        CreateFloor();
        CreateWalls();
        CreateWallObstacles();
        CreateHoleObstacles();
        CreateDoor();

        LevelCreated?.Invoke();
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

                if (y >= 2 && y < _levelHeight - 2)
                    _availableFloorPositions.Add(position);
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
        if (_availableFloorPositions.Count == 0) 
            return;

        for (int i = 0; i < _obstacleWallsCount; i++)
        {
            if (_availableFloorPositions.Count == 0) 
                break;

            int randomIndex = Random.Range(0, _availableFloorPositions.Count);
            Vector3 position = _availableFloorPositions[randomIndex];
            _availableFloorPositions.RemoveAt(randomIndex);
            _occupiedPositions.Add(position);

            Instantiate(_obstacleWallPrefab, position + Vector3.up * (_wallHeight / 2f), Quaternion.identity, transform);
        }
    }

    private void CreateHoleObstacles()
    {
        if (_availableFloorPositions.Count == 0) 
            return;

        for (int i = 0; i < _obstacleHoleCount; i++)
        {
            if (_availableFloorPositions.Count == 0) 
                break;

            int randomIndex = Random.Range(0, _availableFloorPositions.Count);
            Vector3 position = _availableFloorPositions[randomIndex];
            position.y += 0.1f;

            _availableFloorPositions.RemoveAt(randomIndex);
            _occupiedPositions.Add(position);

            Instantiate(_obstacleHolePrefab, position, Quaternion.identity, transform);
        }
    }

    private void CreateDoor()
    {
        Vector3 position = new Vector3(_levelWidth / 2f, _wallHeight / 2f, _levelHeight) - _levelCenter;
        _door = Instantiate(_doorPrefab, position, Quaternion.identity, transform);
        _occupiedPositions.Add(position);
    }

    public Vector3 GetSpawnPointForPlayer()
    {
        Vector3 playerSpawnPosition;

        if (_levelWidth % 2 == 0)
            playerSpawnPosition = new Vector3((_levelWidth / 2f) - 0.5f, 0, 0) - _levelCenter;
        else
            playerSpawnPosition = new Vector3(_levelWidth / 2f, 0, 0) - _levelCenter;

        if (!IsPositionOccupied(playerSpawnPosition))
            return playerSpawnPosition + Vector3.up;

        foreach (var position in _availableFloorPositions)
        {
            if (!IsPositionOccupied(position))
                return position + Vector3.up;
        }

        throw new System.Exception("No valid spawn point found for player.");
    }

    public Vector3 GetSpawnPointForEnemy()
    {
        float minY = _levelHeight / 3f;

        List<Vector3> filteredPositions = new List<Vector3>();
        foreach (var position in _availableFloorPositions)
        {
            if (position.z >= minY && !IsPositionOccupied(position))
            {
                filteredPositions.Add(position);
            }
        }

        if (filteredPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, filteredPositions.Count);
            return filteredPositions[randomIndex] + Vector3.up;
        }

        throw new System.Exception("No valid spawn point found for enemy.");
    }

    public Door GetDoor()
    {
        return _door;
    }

    private bool IsPositionOccupied(Vector3 position)
    {
        return _occupiedPositions.Contains(position);
    }
}