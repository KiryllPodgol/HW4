using System.Collections.Generic;
using UnityEngine;
public class Pool
{
    private readonly Queue<Projectile> _objects = new Queue<Projectile>();
    private readonly Projectile _prefab; 
    private readonly Transform _parent;

    public Pool(Projectile prefab, int initialSize, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            Projectile obj = CreateNewObject();
            _objects.Enqueue(obj);
        }
    }

    private Projectile CreateNewObject()
    {
        Projectile obj = GameObject.Instantiate(_prefab, _parent);
        obj.gameObject.SetActive(false);
        return obj;
    }

    public Projectile Get()
    {
        if (_objects.Count == 0)
        {
            _objects.Enqueue(CreateNewObject());
        }

        Projectile obj = _objects.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnToPool(Projectile obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
    }
}