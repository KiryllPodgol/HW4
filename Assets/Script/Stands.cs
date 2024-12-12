using Script;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public Projectile projectilePrefab; // Префаб снаряда
    public float projectileForce = 500f; // Сила снаряда

    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
            shootingController.SetProjectile(projectilePrefab, projectileForce);
            Debug.Log($"Стенд выдал снаряд: {projectilePrefab.name}");
        }
    }
}