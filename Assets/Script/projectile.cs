using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float impactForce;

    public virtual void ApplyImpact(Rigidbody targetRb, Vector3 forceDirection)
    {
        targetRb.AddForce(forceDirection * impactForce, ForceMode.Force);
    }
}

