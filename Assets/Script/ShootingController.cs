using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform firePoint;
    public float shootForce;
    private Projectile currentProjectile; // ������ �� ������� ������
    private bool canShoot = false;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentProjectile == null) return;
        GameObject projectileInstance = Instantiate(currentProjectile.gameObject, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectileInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootForce);
        }
    }

    public void SetProjectile(Projectile projectile, float force)
    {
        currentProjectile = projectile;
        shootForce = force;
    }

    public void DisableShooting()
    {
        canShoot = false;
    }
}