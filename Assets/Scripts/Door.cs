using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Debug.Log("Level over");
    }

    private void Start()
    {
        _collider.enabled = false;
    }

    public void OpenDoor()
    {
        _collider.enabled = true;
    }
}