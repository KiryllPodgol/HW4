using UnityEngine;

namespace Script
{
    public class Bullet : Projectile
    {
        public float bulletForce = 800f;
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
            if (_trailRenderer != null)
            {
                _trailRenderer.autodestruct = true;
                _trailRenderer.time = trailFadeTime;
            }
        }
    }
}