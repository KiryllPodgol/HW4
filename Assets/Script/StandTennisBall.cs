using Script;
using UnityEngine;
public class TennisStand : MonoBehaviour
{
    public Projectile projectilePrefab; 
    public float projectileForce = 700f;

    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
           
            shootingController.SetProjectile(projectilePrefab, projectileForce);
            Debug.Log("����� �������� ����������� ���: ��������� ������" );
        }
    }
}