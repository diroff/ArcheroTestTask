using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public UnityAction WasUsed;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        WasUsed?.Invoke();
    }

    private void Start()
    {
        _collider.enabled = false;
    }

    public void OpenDoor()
    {
        Debug.Log("Door is available");
        _collider.enabled = true;
    }
}