using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolBehavior : Singleton<PoolBehavior>
{
    private Dictionary<Type, Queue<GameObject>> poolObjects = new();
    private Dictionary<Type, GameObject> prefabMap = new();
    public void Add<T>(GameObject prefab, int count = 10 ) where T : Component
    {
        Type type = typeof(T);
        if (!poolObjects.ContainsKey(type))
        {
            poolObjects[type] = new Queue<GameObject>();
            prefabMap[type] = prefab;

            for (int i = 0; i < count; i++)
            {
                GameObject obj = MonoBehaviour.Instantiate(prefab);
                obj.SetActive(false);
                poolObjects[type].Enqueue(obj);
            }
        }
    }
    public List<T> AddList<T>(GameObject prefab, int count = 10) where T : Component
    {
        Type type = typeof(T);
        List<T> components = new List<T>();

        if (!poolObjects.ContainsKey(type))
        {
            poolObjects[type] = new Queue<GameObject>();
            prefabMap[type] = prefab;
            for (int i = 0; i < count; i++)
            {
                GameObject obj = MonoBehaviour.Instantiate(prefab);
                obj.SetActive(false);
                T component = obj.AddComponent<T>();
                components.Add(component);
                poolObjects[type].Enqueue(obj);
            }
        }
        return components;
    }

    public T Get<T>() where T : Component
    {
        Type type = typeof(T);
        Queue<GameObject> queue = poolObjects[type];
        GameObject obj;        
        obj = queue.Dequeue();
        obj.SetActive(true);
        return obj.GetComponent<T>();
    }
    public IEnumerable<GameObject> GetAllInactiveObjectsOfType<T>() where T : Component
    {
        Type type = typeof(T);
        if (poolObjects.TryGetValue(type, out var queue))
        {
            return queue;
        }
        return new List<GameObject>(); // Return empty if type not found
    }
    public void ReturnToPool<T>(T obj) where T : Component
    {
        Type type = typeof(T);
        obj.gameObject.SetActive(false);
        if (!poolObjects.ContainsKey(type))
        {
            poolObjects[type] = new Queue<GameObject>();
        }
        poolObjects[type].Enqueue(obj.gameObject);
    }
}
