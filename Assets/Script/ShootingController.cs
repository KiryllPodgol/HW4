using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class ShootingController : MonoBehaviour
    {
        public Transform firePoint;
        public float shootForce;
        private Projectile _currentProjectile;
        private InputAsset _inputAsset; 
        private bool _canShoot = false;

        private void Awake()
        {
            _inputAsset = new InputAsset();
        }

        void OnEnable()
        {
            _inputAsset.Gameplay.Enable();
            _inputAsset.Gameplay.Shoot.started += ShootOnstarted;
        }

        private void ShootOnstarted(InputAction.CallbackContext obj)
        {
            if (_canShoot)
            {
                Shoot();
                AudioManager.Instance.PlayShootSound();
                Debug.Log("Выстрелил");
            }
        }

        void OnDisable()
        {
            _inputAsset.Gameplay.Shoot.started -= ShootOnstarted;
            _inputAsset.Gameplay.Disable();
        }

        void Start()
        {
            _canShoot = true;
        }

        void Shoot()
        {
            if (_currentProjectile == null) return;

            // Получаем пул снаряда и запускаем его
            Projectile projectileInstance = (Projectile)BulletManager.Instance.GetBullet(
                _currentProjectile, firePoint.position, firePoint.rotation);

            projectileInstance.Launch(firePoint.forward);
        }

        // Исправление: проверка типа перед приведением
        public void SetProjectile(IPoolable projectile, float force)
        {
            // Проверяем, является ли объект типа IPoolable также типом Projectile
            if (projectile is Projectile proj)
            {
                _currentProjectile = proj;
                shootForce = force;
            }
            else
            {
                Debug.LogError("Переданный объект не является типом Projectile!");
            }
        }

        public void DisableShooting()
        {
            _canShoot = false;
        }
    }
}
