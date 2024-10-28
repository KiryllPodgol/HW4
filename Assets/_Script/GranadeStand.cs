using UnityEngine;

public class GranadeStand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
            shootingController.EnableGrenadeShooting();
            Debug.Log("Режим стрельбы гранатами активирован.");
        }
    }
}