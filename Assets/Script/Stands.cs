using Script;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public Projectile projectilePrefab; // ?????? ???????
    public float projectileForce = 500f; // ???? ???????

    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
            shootingController.SetProjectile(projectilePrefab, projectileForce);
            Debug.Log($"????? ????? ??????: {projectilePrefab.name}");
        }
    }
}