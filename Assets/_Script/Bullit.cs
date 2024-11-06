using UnityEngine;

public class Bullit : MonoBehaviour
{
    public float impactForce = 500f; 

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
            targetRb.AddForce(forceDirection * impactForce, ForceMode.Force);
        }

      
        Destroy(gameObject);
    }
}
