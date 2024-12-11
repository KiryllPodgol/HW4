using Script;
using UnityEngine;

public class StandBullet : MonoBehaviour
{
    public Bullet bulletProjectilePrefab;
    public float bulletForce = 500f;


    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
           
            shootingController.SetProjectile(bulletProjectilePrefab, bulletForce);
            Debug.Log("����� �������� ������ �����������.");
        }
    }
}
