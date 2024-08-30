using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera _camera;
    [SerializeField] private LevelGenerator _levelGenerator;

    [SerializeField] private float _fovOffSet = 20f;

    private int _currentScreenWidth;
    private int _currentScreenHeight;

    private void OnEnable()
    {
        _levelGenerator.LevelCreated += AdjustCamera;
    }

    private void OnDisable()
    {
        _levelGenerator.LevelCreated -= AdjustCamera;
    }

    private void Start()
    {
        _currentScreenWidth = Screen.width;
        _currentScreenHeight = Screen.height;
    }

    private void Update()
    {
        if (Screen.width == _currentScreenWidth && Screen.height == _currentScreenHeight)
            return;

        _currentScreenWidth = Screen.width;
        _currentScreenHeight = Screen.height;
        AdjustCamera();
    }

    private void AdjustCamera()
    {
        float levelWidth = _levelGenerator.GetLevelWidth();
        float levelHeight = _levelGenerator.GetLevelHeight();

        Vector3 levelCenter = new Vector3(levelWidth / 2f, 0, levelHeight / 2f);
        _camera.transform.position = new Vector3(levelCenter.x, Mathf.Max(levelWidth, levelHeight), levelCenter.z);

        float aspectRatio = (float)Screen.width / Screen.height;
        float distanceToLevel = _camera.transform.position.y;

        float verticalFOV = 2f * Mathf.Atan((levelHeight / 2f) / distanceToLevel) * Mathf.Rad2Deg;
        float horizontalFOV = 2f * Mathf.Atan((levelWidth / 2f) / distanceToLevel / aspectRatio) * Mathf.Rad2Deg;

        _camera.fieldOfView = Mathf.Max(verticalFOV, horizontalFOV) + _fovOffSet;
        _camera.transform.LookAt(levelCenter);
    }
}