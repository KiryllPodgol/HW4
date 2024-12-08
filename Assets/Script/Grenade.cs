using System;
using UnityEngine;

public class Grenade : Projectile
{
    public GameObject explossionEffect;
    public float explosionEffectliveTime = 2f;
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        rb.excludeLayers = LayerMask.GetMask("Robot");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        GameObject explosion =  Instantiate(explossionEffect, transform.position, transform.rotation);
         
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
               
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
        Destroy(explosion, explosionEffectliveTime);
    }
}