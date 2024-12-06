using UnityEngine;
public class GrenadeStand : MonoBehaviour
{
    public Grenade grenadeProjectilePrefab;
    public float grenadeForce = 1000f;

    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
            
            shootingController.SetProjectile(grenadeProjectilePrefab, grenadeForce);
            Debug.Log("����� �������� ��������� �����������.");
        }
    }
}

