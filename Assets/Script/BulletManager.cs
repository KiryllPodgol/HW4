using UnityEngine;
using System.Collections.Generic;
using Script;

public class BulletManager : Singleton<BulletManager>
{
    [Header("Bullet Pool Settings")]
    [SerializeField] private List<PoolObjectInfo> bulletPoolInfos;

    private Dictionary<Projectile, Pool> bulletPools;

    protected override void Awake()
    {
        base.Awake();
        InitializePools();
    }
    private void InitializePools()
    {
        bulletPools = new Dictionary<Projectile, Pool>();

        foreach (var poolInfo in bulletPoolInfos)
        {
            if (poolInfo.prefab == null) continue;

          
            Pool pool = new Pool(poolInfo.prefab, poolInfo.initialSize, this.transform);
            bulletPools.Add(poolInfo.prefab, pool);
        }
    }
    public Projectile GetBullet(Projectile prefab, Vector3 position, Quaternion rotation)
    {
        if (!bulletPools.ContainsKey(prefab))
        {
            Debug.LogWarning($"Pool for {prefab.name} not found. Creating a new pool dynamically.");
            bulletPools[prefab] = new Pool(prefab, 5, this.transform);
        }

        Projectile bullet = bulletPools[prefab].Get();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        return bullet;
    }
    public void ReturnBullet(Projectile prefab, Projectile bullet)
    {
        if (bulletPools.ContainsKey(prefab))
        {
            bulletPools[prefab].ReturnToPool(bullet);
        }
        else
        {
            Debug.LogError("Trying to return bullet to a non-existing pool.");
            Destroy(bullet.gameObject);
        }
    }
}