using UnityEngine;

public class Grenade : Projectile
{
    public ParticleSystem explosionEffect; 
    public float explosionEffectLifetime = 2f;
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    protected override void ApplyImapct(Collision collision)
    {
        ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.Play();
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        AudioManager.Instance.PlayExplosionSound();
        Destroy(explosion.gameObject, explosionEffectLifetime);
    }
}