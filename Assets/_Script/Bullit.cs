using UnityEngine;

public class Bullit : MonoBehaviour
{
    public float impactForce = 400f; 

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        // Rigidbody объекта, с которым столкнулась пуля
        Rigidbody targetRb = collision.collider.GetComponent<Rigidbody>();

        if (targetRb != null)
        {
            //  сила в точке столкновения, чтобы сдвинуть объект
            Vector3 forceDirection = GetComponent<Rigidbody>().linearVelocity.normalized;
            targetRb.AddForce(forceDirection * impactForce, ForceMode.Force);
        }

      
        Destroy(gameObject);
    }
}
