using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovementInstaller : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        _fighter.SetMovableStrategy(new FlyingMovement(_rigidbody, _fighter.CurrentSpeed));
    }
}
