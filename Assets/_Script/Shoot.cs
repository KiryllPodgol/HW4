using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject spherePrefab;
    public GameObject tennisBallPrefab;
    public Transform firePoint;         
    public float shootForce;    

    private GameObject currentProjectile; // Текущий тип снаряда
    private bool canShoot = false;        

    void Start()
    {
       
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

        // значение shootForce в скрипт Bullit
        Bullit bullitScript = projectile.GetComponent<Bullit>();
        if (bullitScript != null)
        {
            bullitScript.impactForce = shootForce;
        }
    }

    //обычный снаряд
    public void EnableSphereShooting()
    {
        currentProjectile = spherePrefab;
        shootForce = 700f;
        canShoot = true;
    }

    
    public void EnableTennisBallShooting()
    {
        currentProjectile = tennisBallPrefab;
        shootForce = 700f;
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
