using UnityEngine;

public class GroundMovementInstaller : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        _fighter.SetMovableStrategy(new GroundMovement(_rigidbody, _fighter.CurrentSpeed));
    }
}