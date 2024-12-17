using System.Collections.Generic;
using UnityEngine;
public class Pool
{
    private readonly Queue<IPoolable> _objects = new Queue<IPoolable>();
    private readonly IPoolable _prefab;
    private readonly Transform _parent;

    public Pool(IPoolable prefab, int initialSize, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            IPoolable obj = CreateNewObject();
            _objects.Enqueue(obj);
        }
    }

    private IPoolable CreateNewObject()
    {
        IPoolable obj = (IPoolable)GameObject.Instantiate(_prefab as MonoBehaviour, _parent);
        obj.OnObjectDespawn(); // Деактивировать объект сразу
        return obj;
    }

    public IPoolable Get()
    {
        if (_objects.Count == 0)
        {
            _objects.Enqueue(CreateNewObject());
        }

        IPoolable obj = _objects.Dequeue();
        obj.OnObjectSpawn(); // Активировать объект
        return obj;
    }

    public void ReturnToPool(IPoolable obj)
    {
        obj.OnObjectDespawn(); // Деактивировать объект перед возвращением в пул
        _objects.Enqueue(obj);
    }
}
