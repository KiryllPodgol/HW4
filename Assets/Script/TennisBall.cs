using UnityEngine;

public class TennisBall : Projectile
{
    private TrailRenderer trail;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        rb.excludeLayers = LayerMask.GetMask("Robot");
        trail = GetComponent<TrailRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (trail != null)
        {
            trail.enabled = true;
           
            StartCoroutine(DisableTrailAfterTime(0.3f));
        }

        Destroy(gameObject, 2.0f);
    }

    private System.Collections.IEnumerator DisableTrailAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (trail != null)
        {
            trail.enabled = false; 
        }
    }
}