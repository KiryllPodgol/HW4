using UnityEngine;

public class StandBall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ShootingController shootingController = other.GetComponent<ShootingController>();
        if (shootingController != null)
        {
            shootingController.EnableTennisBallShooting();
            Debug.Log("–ежим стрельбы теннисными м€чами активирован.");
        }
    }

    
}
