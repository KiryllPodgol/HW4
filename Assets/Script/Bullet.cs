using UnityEngine;

namespace Script
{
    public class Bullet : Projectile
    {
        public ParticleSystem impactParticlesPrefab;
        public float trailFadeTime = 0.2f;
        private TrailRenderer _trailRenderer;

        protected override void Awake()
        {
            base.Awake();
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        protected override void ApplyImapct(Collision collision)
        {
            base.ApplyImapct(collision);
            AudioManager.Instance.PlayHitSound();
            if (impactParticlesPrefab != null)
            {
                PlayImpactParticles(collision.contacts[0].point, collision.contacts[0].normal);
            }
            else
            {
                Debug.LogWarning("impactParticlesPrefab is not assigned in the inspector.");
            }
            if (_trailRenderer != null)
            {
                _trailRenderer.autodestruct = true;
                _trailRenderer.time = trailFadeTime;
            }
        }

        private void PlayImpactParticles(Vector3 position, Vector3 normal)
        {
            ParticleSystem impactParticles = Instantiate(impactParticlesPrefab, position, Quaternion.LookRotation(normal));
            impactParticles.Play();
            Destroy(impactParticles.gameObject, impactParticles.main.duration);
        }
    }
}