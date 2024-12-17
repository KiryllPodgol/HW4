using UnityEngine;

public abstract class Projectile : MonoBehaviour, IPoolable
{
    [SerializeField] float _force;
    protected Rigidbody _rb;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (!_rb)
        {
            Debug.Log("Rigidbody attached to projectile is null");
        }
    }

    public virtual void Launch(Vector3 direction)
    {
        _rb.AddForce(direction * _force);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        ApplyImpact(collision);
        BulletManager.Instance.ReturnBullet(this);
    }

    public float impactForce;
    protected virtual void ApplyImpact(Collision collision)
    {
        Rigidbody targetRb = collision.collider.GetComponent<Rigidbody>();
        if (!targetRb)
        {
            return;
        }

        Vector3 forceDirection = _rb.linearVelocity.normalized;
        targetRb.AddForce(forceDirection * impactForce, ForceMode.Impulse);
    }

    // ���������� ������� ���������� IPoolable
    public void OnObjectSpawn()
    {
        gameObject.SetActive(true); // ��������� �������
    }

    public void OnObjectDespawn()
    {
        gameObject.SetActive(false); // ����������� �������
    }
}
