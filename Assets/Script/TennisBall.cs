using UnityEngine;
public class TennisBall : Projectile
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
                
                
        }
            
    }
}