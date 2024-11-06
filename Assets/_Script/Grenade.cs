using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

       
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected, explosion aborted.");
            return;
        }

        Explode();
    }

    void Explode()
    {
        Debug.Log("Explosion initiated.");

        // Находим все объекты с Rigidbody в радиусе взрыва
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