using UnityEngine;

public class Bullet : Projectile
{
    public float bulletForce = 800f;
    
    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        rb.excludeLayers = LayerMask.GetMask("Robot");
        
    }
    private void Start()
    {
        // Применяемая сила к пуле при её создании
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * bulletForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        Rigidbody targetRb = collision.collider.GetComponent<Rigidbody>();

        if (targetRb != null)
        {
            Vector3 forceDirection = GetComponent<Rigidbody>().linearVelocity.normalized;
            ApplyImpact(targetRb, forceDirection);
        }

        Destroy(gameObject);
    }
}