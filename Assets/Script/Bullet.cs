using UnityEngine;

public class Bullet : Projectile
{
    public float bulletForce = 800f; 
    public float trailFadeTime = 0.2f; 
    private TrailRenderer _trailRenderer;
    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        rb.excludeLayers = LayerMask.GetMask("Robot");
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
       
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * bulletForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody targetRb = collision.collider.GetComponent<Rigidbody>();

        if (targetRb != null)
        {
            Vector3 forceDirection = GetComponent<Rigidbody>().linearVelocity.normalized;
            ApplyImpact(targetRb, forceDirection);
        }
        if (_trailRenderer != null)
        {
            _trailRenderer.autodestruct = true; 
            _trailRenderer.time = trailFadeTime; 
        }
        Destroy(gameObject); 
    }
}