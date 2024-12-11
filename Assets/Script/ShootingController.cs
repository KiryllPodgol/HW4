using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class ShootingController : MonoBehaviour
    {
        public Transform firePoint;
        public float shootForce;
        private Projectile _currentProjectile; // тип снаряда
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
            Projectile projectileInstance = Instantiate(_currentProjectile, firePoint.position, firePoint.rotation);
            projectileInstance.Launch(firePoint.forward);
        }

        public void SetProjectile(Projectile projectile, float force)
        {
            _currentProjectile = projectile;
            shootForce = force;
        }

        public void DisableShooting()
        {
            _canShoot = false;
        }
    }
}