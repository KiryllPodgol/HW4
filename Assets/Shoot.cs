using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject spherePrefab;     // ������ �������� �������
    public GameObject tennisBallPrefab;
    public Transform firePoint;         // ����� ��������
    public float shootForce = 700f;     // ���� ��������

    private GameObject currentProjectile; // ������� ��� �������
    private bool canShoot = false;        // ���� ��� ���������� ��������

    void Start()
    {
        // ������ � �������� �������
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

    // ����� ��� ������������ �� ������� �������
    public void EnableSphereShooting()
    {
        currentProjectile = spherePrefab;
        canShoot = true;
    }

    // ����� ��� ������������ �� ��������� ����
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
