using UnityEngine;

public class TennisBallStand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
            shootingController.EnableSphereShooting();
            Debug.Log("Режим стрельбы пулями активирован.");
        }
    }

}