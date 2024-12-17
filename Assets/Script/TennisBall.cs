using UnityEngine;

public class TennisBall : Projectile
{
    private TrailRenderer trail;

    protected override void Awake()
    {
        base.Awake();
        trail = GetComponent<TrailRenderer>();
    }

    public override void Launch(Vector3 direction)
    {
        base.Launch(direction);
        
        Destroy(gameObject,3.0f);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        ApplyImpact(collision);
        AudioManager.Instance.PlayBounceSound();
        StartCoroutine(DisableTrailAfterTime(0.3f));
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