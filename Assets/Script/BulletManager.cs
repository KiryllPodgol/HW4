using UnityEngine;
using System.Collections.Generic;
using Script;

public class BulletManager : Singleton<BulletManager>
{
    [Header("Bullet Pool Settings")]
    [SerializeField] private List<PoolObjectInfo> bulletPoolInfos;

    private Dictionary<IPoolable, Pool> bulletPools;

    protected override void Awake()
    {
        base.Awake();
        InitializePools();
    }

    private void InitializePools()
    {
        bulletPools = new Dictionary<IPoolable, Pool>();

        foreach (var poolInfo in bulletPoolInfos)
        {
            if (poolInfo.prefab == null) continue;

            Pool pool = new Pool(poolInfo.prefab, poolInfo.initialSize, this.transform);
            bulletPools.Add(poolInfo.prefab, pool);
        }
    }

    public IPoolable GetBullet(IPoolable prefab, Vector3 position, Quaternion rotation)
    {
        if (!bulletPools.ContainsKey(prefab))
        {
            Debug.LogWarning($"Pool for {prefab} not found. Creating a new pool dynamically.");
            bulletPools[prefab] = new Pool(prefab, 5, this.transform);
        }

        IPoolable bullet = bulletPools[prefab].Get();
        // Здесь можно установить позицию и вращение для специфичных объектов
        return bullet;
    }

    public void ReturnBullet(IPoolable bullet)
    {
        foreach (var pool in bulletPools.Values)
        {
            pool.ReturnToPool(bullet);
        }
    }
}
