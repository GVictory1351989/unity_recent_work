using System;
using System.Collections.Generic;
using UnityEngine;
public static class PoolManager
{
    private static Dictionary<Type, Queue<GameObject>> poolObjects = new();
    private static Dictionary<Type, GameObject> prefabMap = new();
    public  static Func<Type, Component> GetByType;
    static PoolManager()
    {
        InitializeDelegates();
    }
    public static void InitializeDelegates()
    {
        GetByType = (type) =>
        {
            if (type == typeof(MeleeEnemy)) return Get<MeleeEnemy>();
            if (type == typeof(RangedEnemy)) return Get<RangedEnemy>();
            if (type == typeof(ExplodedEnemy)) return Get<ExplodedEnemy>();
            if (type == typeof(BulletFSM)) return Get<BulletFSM>();
            if (type == typeof(MissileFSM)) return Get<MissileFSM>();
            return null;
        };
    }
    public static bool HasPool(Type type) => poolObjects.ContainsKey(type);
    public static void Add<T>(GameObject prefab, int count = 10 ) where T : Component
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
    public static List<T> AddList<T>(GameObject prefab, int count = 10) where T : Component
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

    private static T Get<T>() where T : Component
    {
        Type type = typeof(T);
        Queue<GameObject> queue = poolObjects[type];
        GameObject obj;        
        obj = queue.Dequeue();
        obj.SetActive(true);
        return obj.GetComponent<T>();
    }
    public static IEnumerable<GameObject> GetAllInactiveObjectsOfType<T>() where T : Component
    {
        Type type = typeof(T);
        if (poolObjects.TryGetValue(type, out var queue))
        {
            return queue;
        }
        return new List<GameObject>(); // Return empty if type not found
    }
    public static void ReturnToPool<T>(T obj) where T : Component
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
