using UnityEngine;
using System.Collections.Generic;

public class BulletManager : Singleton<BulletManager>
{
    public GameObject bulletPrefab; // Префаб пули
    public int initialPoolSize = 10;

    private List<Projectile> _bulletPool;

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        _bulletPool = new List<Projectile>();
        for (int i = 0; i < initialPoolSize; i++)
        {
            Projectile bullet = CreateBullet();
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
        }
    }

    private Projectile CreateBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        if (!bulletObject.TryGetComponent(out Projectile bullet))
        {
            bullet = bulletObject.AddComponent<Projectile>();
        }
        return bullet;
    }

    public Projectile GetBullet(Vector3 position, Quaternion rotation)
    {
        foreach (Projectile bullet in _bulletPool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }
        Projectile newBullet = CreateBullet();
        newBullet.transform.position = position;
        newBullet.transform.rotation = rotation;
        newBullet.gameObject.SetActive(true);
        _bulletPool.Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(Projectile bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}