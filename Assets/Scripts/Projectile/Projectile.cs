using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [field: SerializeField] public ProjectileData CurrentData { get; protected set; }

    [SerializeField] protected Rigidbody Rigidbody;
    [SerializeField] private Collider _collider;

    protected float CurrentSpeed;
    protected float CurrentDamage;
    protected float CurrentLifeTime;

    private float _damageFromWeapon;
    private float _timeSinceLaunch;

    private GameObject _owner;

    private void OnEnable()
    {
        _timeSinceLaunch = 0f;
    }

    public void SetData(ProjectileData data, RangedWeapon weapon)
    {
        CurrentData = data;

        CurrentSpeed = data.BaseSpeed;
        CurrentDamage = data.BaseDamage;
        CurrentLifeTime = data.LifeTime;

        _damageFromWeapon = weapon.CalculateDamage();

        _owner = weapon.Owner.gameObject;
        Debug.Log(_owner);
    }

    public void Launch(Vector3 direction)
    {
        _collider.enabled = true;
        Rigidbody.velocity = direction.normalized * CurrentSpeed;
    }

    private void Update()
    {
        _timeSinceLaunch += Time.deltaTime;

        if (_timeSinceLaunch >= CurrentLifeTime)
            Deactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _owner)
            return;

        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
            damagable.TakeDamage(CalculateTotalDamage());

        Deactivate();
    }

    public virtual float CalculateTotalDamage()
    {
        return _damageFromWeapon + CurrentDamage;
    }

    private void Deactivate()
    {
        _collider.enabled = false;
        Destroy(gameObject);
    }
}