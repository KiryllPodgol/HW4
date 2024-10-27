using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public float delayBeforeExplosion = 0.1f; 

    private bool canExplode = false; 

    private void Start()
    {
       
        Invoke("EnableExplosion", delayBeforeExplosion);
    }

    private void EnableExplosion()
    {
        canExplode = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (canExplode)
        {
            Explode();
        }
    }

    void Explode()
    {
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
    }
}
