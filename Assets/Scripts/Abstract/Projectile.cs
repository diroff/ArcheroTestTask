using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] protected Rigidbody Rigidbody;

    protected float CurrentSpeed;
    protected float CurrentDamage;
    protected float CurrentLifeTime;

    private float _damageFromWeapon;
    private float _timeSinceLaunch;

    public ProjectileData CurrentData { get; protected set; }

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
    }

    public void Launch(Vector3 direction)
    {
        Rigidbody.velocity = direction.normalized * CurrentSpeed;
    }

    private void Update()
    {
        _timeSinceLaunch += Time.deltaTime;

        if (_timeSinceLaunch >= CurrentLifeTime)
            Deactivate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

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
        Destroy(gameObject);
    }
}