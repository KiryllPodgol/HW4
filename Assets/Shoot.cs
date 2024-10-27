using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject spherePrefab;     // Префаб обычного снаряда
    public GameObject tennisBallPrefab;
    public Transform firePoint;         // Точка выстрела
    public float shootForce = 700f;     // Сила выстрела

    private GameObject currentProjectile; // Текущий тип снаряда
    private bool canShoot = false;        // Флаг для разрешения стрельбы

    void Start()
    {
        // Начнем с обычного снаряда
        currentProjectile = spherePrefab;
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
        GameObject projectile = Instantiate(currentProjectile, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootForce);
        }
    }

    // Метод для переключения на обычные снаряды
    public void EnableSphereShooting()
    {
        currentProjectile = spherePrefab;
        canShoot = true;
    }

    // Метод для переключения на теннисные мячи
    public void EnableTennisBallShooting()
    {
        currentProjectile = tennisBallPrefab;
        canShoot = true;
    }
    public void EnableGrenadeShooting()
    {
        currentProjectile = grenadePrefab;
        canShoot = true;
    }


    public void DisableShooting()
    {
        canShoot = false;
    }
}
